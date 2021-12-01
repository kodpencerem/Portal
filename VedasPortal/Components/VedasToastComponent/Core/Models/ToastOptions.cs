
using System;
using System.Threading.Tasks;

namespace VedasPortal.Components.VedasToastComponent.Core.Models
{
    /// <summary>
    /// Sınıflara yönelik ayarlamaları yapar.
    /// </summary>
    public class ToastOptions : CommonToastOptions
    {
        /// <summary>
        /// Kullanıcı tıklamasıyla çağrılacak olan fonksiyon bilgisi <see cref="Func{Toast,Task}"/>
        /// </summary>
        public Func<VedasToast, Task> Onclick { get; set; }

        /// <summary>
        /// Nesne tipi <see cref="ToastType"/>
        /// </summary>
        public ToastType Type { get; }

        /// <summary>
        /// ToastType için css ayarlamalarını yapar
        /// </summary>
        public string ToastTypeClass { get; set; }

        public ToastOptions(ToastType type, ToasterConfiguration configuration)
        {
            Type = type;
            ToastTypeClass = configuration.ToastTypeClass(type);

            ToastClass = configuration.ToastClass;
            ToastTitleClass = configuration.ToastTitleClass;
            ToastMessageClass = configuration.ToastMessageClass;
            MaximumOpacity = configuration.MaximumOpacity;

            ShowTransitionDuration = configuration.ShowTransitionDuration;

            VisibleStateDuration = configuration.VisibleStateDuration;

            HideTransitionDuration = configuration.HideTransitionDuration;

            ShowProgressBar = configuration.ShowProgressBar;
            ProgressBarClass = configuration.ProgressBarClass;

            ShowCloseIcon = configuration.ShowCloseIcon;
            CloseIconClass = configuration.CloseIconClass;

            RequireInteraction = configuration.RequireInteraction;
        }
    }
}