using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using VedasPortal.Components.VedasToastComponent.Core.Models;
using VedasPortal.Components.VedasToastComponent.Extensions;

namespace VedasPortal.Components.VedasToastComponent.Core
{
    /// <inheritdoc />
    internal class VedasToaster : IVedasToaster
    {
        public ToasterConfiguration Configuration { get; }
        public event Action OnToastsUpdated;
        public string Version { get; }

        private ReaderWriterLockSlim ToastLock { get; }
        private IList<VedasToast> Toasts { get; }

        public VedasToaster(ToasterConfiguration configuration)
        {
            Configuration = configuration;
            Configuration.OnUpdate += ConfigurationUpdated;

            ToastLock = new ReaderWriterLockSlim();
            Toasts = new List<VedasToast>();
            Version = GetType().InformationalVersion();
        }

        public void Info(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Info, message, title, configure);
        }

        public void Success(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Success, message, title, configure);
        }

        public void Warning(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Warning, message, title, configure);
        }

        public void Error(string message, string title = null, Action<ToastOptions> configure = null)
        {
            Add(ToastType.Error, message, title, configure);
        }

        public IEnumerable<VedasToast> ShownToasts
        {
            get
            {
                ToastLock.EnterReadLock();
                try
                {
                    return Toasts.Take(Configuration.MaxDisplayedToasts);
                }
                finally
                {
                    ToastLock.ExitReadLock();
                }
            }
        }

        public void Add(ToastType type, string message, string title, Action<ToastOptions> configure)
        {
            if (message.IsEmpty()) return;

            message = message.Trimmed();
            title = title.Trimmed();

            var options = new ToastOptions(type, Configuration);
            configure?.Invoke(options);

            var toast = new VedasToast(title, message, options);

            ToastLock.EnterWriteLock();
            try
            {
                if (Configuration.PreventDuplicates && ToastAlreadyPresent(toast)) return;
                toast.OnClose += Remove;
                Toasts.Add(toast);
            }
            finally
            {
                ToastLock.ExitWriteLock();
            }

            OnToastsUpdated?.Invoke();
        }

        public void Clear()
        {
            ToastLock.EnterWriteLock();
            try
            {
                RemoveAllToasts(Toasts);
            }
            finally
            {
                ToastLock.ExitWriteLock();
            }

            OnToastsUpdated?.Invoke();
        }

        public void Remove(VedasToast toast)
        {
            toast.Dispose();
            toast.OnClose -= Remove;

            ToastLock.EnterWriteLock();
            try
            {
                var index = Toasts.IndexOf(toast);
                if (index < 0) return;
                Toasts.RemoveAt(index);
            }
            finally
            {
                ToastLock.ExitWriteLock();
            }

            OnToastsUpdated?.Invoke();
        }

        private bool ToastAlreadyPresent(VedasToast newToast)
        {
            return Toasts.Any(toast =>
                newToast.Message.Equals(toast.Message) &&
                newToast.Title.Equals(toast.Title) &&
                newToast.Type.Equals(toast.Type)
            );
        }

        private void ConfigurationUpdated()
        {
            OnToastsUpdated?.Invoke();
        }

        public void Dispose()
        {
            Configuration.OnUpdate -= ConfigurationUpdated;
            RemoveAllToasts(Toasts);
        }

        private void RemoveAllToasts(IEnumerable<VedasToast> toasts)
        {
            if (Toasts.Count == 0) return;

            foreach (var toast in toasts)
            {
                toast.OnClose -= Remove;
                toast.Dispose();
            }

            Toasts.Clear();
        }
    }
}