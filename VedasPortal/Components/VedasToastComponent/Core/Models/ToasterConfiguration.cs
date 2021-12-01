

using System;

namespace VedasPortal.Components.VedasToastComponent.Core.Models
{
    /// <summary>
    /// <see cref="ToasterConfiguration"/> genel ayarları ifade eder.
    /// </summary>
    public class ToasterConfiguration : CommonToastOptions
    {
        private bool _newestOnTop;
        private bool _preventDuplicates;
        private int _maxDisplayedToasts;
        private string _positionClass;

        internal event Action OnUpdate;

        /// <summary>
        /// NewestOnTop görüntüleme sırasını yönlendirir: doğru olduğunda, en yeni görüntülenebilir NewestOnTop en üstte olacaktır. Aksi takdirde altta kalır. Varsayılan olarak false olur.
        /// </summary>
        public bool NewestOnTop
        {
            get => _newestOnTop;
            set
            {
                _newestOnTop = value;
                OnUpdate?.Invoke();
            }
        }

        /// <summary>
        /// Doğru olduğunda, aynı türde, başlıkta ve halihazırda mevcut olan bir PreventDuplicates aynı mesaja sahip yeni bir PreventDuplicates yok sayılır. Varsayılan olarak true olur.
        /// </summary>
        public bool PreventDuplicates
        {
            get => _preventDuplicates;
            set
            {
                _preventDuplicates = value;
                OnUpdate?.Invoke();
            }
        }

        /// <summary>
        /// Aynı anda gösterilecek maksimum MaxDisplayedToasts sayısı. Varsayılan 5 olarak ayarlanmıştır
        /// </summary>
        public int MaxDisplayedToasts
        {
            get => _maxDisplayedToasts;
            set
            {
                _maxDisplayedToasts = value;
                OnUpdate?.Invoke();
            }
        }

        /// <summary>
        /// Ekranda toast konumunu süren css sınıfı. Önceden tanımlanmış konumlar <see cref="Defaults.Classes.Position"/> içinde bulunur. Varsayılan olarak <see cref="Defaults.Classes.Position.TopRight"/>
        /// </summary>
        public string PositionClass
        {
            get => _positionClass;
            set
            {
                _positionClass = value;
                OnUpdate?.Invoke();
            }
        }

        /// <summary>
        ///  Tüm<see cref="ToastState"/> durumları için css sınıflarını içeren bir <see cref="ToastIconClasses"/> örneği.
        /// </summary>
        public ToastIconClasses IconClasses = new ToastIconClasses();

        public ToasterConfiguration()
        {
            PositionClass = Defaults.Classes.Position.TopRight;
            NewestOnTop = false;
            PreventDuplicates = true;
            MaxDisplayedToasts = 5;
        }

        internal string ToastTypeClass(ToastType type)
        {
            switch (type)
            {
                case ToastType.Info: return IconClasses.Info;
                case ToastType.Error: return IconClasses.Error;
                case ToastType.Success: return IconClasses.Success;
                case ToastType.Warning: return IconClasses.Warning;
                default: return IconClasses.Info;
            }
        }
    }
}