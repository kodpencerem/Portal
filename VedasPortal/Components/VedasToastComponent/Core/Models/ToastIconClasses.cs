namespace VedasPortal.Components.VedasToastComponent.Core.Models
{
    /// <summary>
    /// <see cref="ToastState"/> için kullanılacak css sınıflarını tanımlar
    /// </summary>
    public class ToastIconClasses
    {
        /// <summary>
        /// Bilgi için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="CheckBoxRadioBase.Classes.Icons.Info"/>
        /// </summary>
        public string Info { get; set; } = CheckBoxRadioBase.Classes.Icons.Info;

        /// <summary>
        /// Success için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="CheckBoxRadioBase.Classes.Icons.Success"/>
        /// </summary>
        public string Success { get; set; } = CheckBoxRadioBase.Classes.Icons.Success;

        /// <summary>
        /// Success için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="CheckBoxRadioBase.Classes.Icons.Warning"/>
        /// </summary>
        public string Warning { get; set; } = CheckBoxRadioBase.Classes.Icons.Warning;

        /// <summary>
        /// Success için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="CheckBoxRadioBase.Classes.Icons.Error"/>
        /// </summary>
        public string Error { get; set; } = CheckBoxRadioBase.Classes.Icons.Error;
    }
}