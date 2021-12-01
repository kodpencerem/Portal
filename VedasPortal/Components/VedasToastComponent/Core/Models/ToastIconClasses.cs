
namespace VedasPortal.Components.VedasToastComponent.Core.Models
{
    /// <summary>
    /// <see cref="ToastState"/> için kullanılacak css sınıflarını tanımlar
    /// </summary>
    public class ToastIconClasses
    {
        /// <summary>
        /// Bilgi için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="Defaults.Classes.Icons.Info"/>
        /// </summary>
        public string Info { get; set; } = Defaults.Classes.Icons.Info;

        /// <summary>
        /// Success için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="Defaults.Classes.Icons.Success"/>
        /// </summary>
        public string Success { get; set; } = Defaults.Classes.Icons.Success;

        /// <summary>
        /// Success için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="Defaults.Classes.Icons.Warning"/>
        /// </summary>
        public string Warning { get; set; } = Defaults.Classes.Icons.Warning;

        /// <summary>
        /// Success için css sınıfı <see cref="ToastState"/>. Varsayılan olarak <see cref="Defaults.Classes.Icons.Error"/>
        /// </summary>
        public string Error { get; set; } = Defaults.Classes.Icons.Error;
    }
}