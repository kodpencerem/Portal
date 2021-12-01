using System;
using System.Collections.Generic;
using VedasPortal.Components.VedasToastComponent.Core;
using VedasPortal.Components.VedasToastComponent.Core.Models;

namespace VedasPortal.Components.VedasToastComponent
{
    /// <inheritdoc />
    /// <summary>
    /// Toaster nesnesinin bir örneğini temsil eder
    /// </summary>
    public interface IVedasToaster : IDisposable
    {
        /// <summary>
        /// Toast'ı bir liste şeklinde gösterir
        /// </summary>
        IEnumerable<VedasToast> ShownToasts { get; }

        /// <summary>
        /// Global konfigrasyon <see cref="ToasterConfiguration"/> 
        /// </summary>
        ToasterConfiguration Configuration { get; }

        /// <summary>
        /// Toster versiyon bilgisini döner
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Toast listesi değiştiğinde veya genel bir yapılandırma ayarı değiştirildiğinde ortaya çıkan bir event
        /// </summary>
        event Action OnToastsUpdated;

        /// <summary>
        /// Bilgi vermek için kullanılan nesne örneği
        /// </summary>
        /// <param name="message">Mesaj metin içeriği</param>
        /// <param name="title">Bilgi mesajı başlığı</param>
        /// <param name="configure">Konfigürasyon  <see cref="ToastOptions"/> genel ayarlarını içerir</param>
        void Info(string message, string title = null, Action<ToastOptions> configure = null);

        /// <summary>
        /// Tamamlanmış veya onaylanmış nesnelere yönelik mesaj döndürür
        /// </summary>
        /// <param name="message">Success mesaj içeriği</param>
        /// <param name="title">Mesaj başlığı</param>
        /// <param name="configure">Konfigürasyon  <see cref="ToastOptions"/> genel ayarlarını içerir</param>
        void Success(string message, string title = null, Action<ToastOptions> configure = null);

        /// <summary>
        /// Uyarı bilgilerini vermek için kullanılır
        /// </summary>
        /// <param name="message">Uyarı mesajı metin bilgisi </param>
        /// <param name="title">Uyarı mesaj başlığı </param>
        /// <param name="configure">Konfigürasyon  <see cref="ToastOptions"/> genel ayarlarını içerir</param>
        void Warning(string message, string title = null, Action<ToastOptions> configure = null);

        /// <summary>
        /// Hata mesajları vermek için kullanılır
        /// </summary>
        /// <param name="message">Hata mesajı içeriği</param>
        /// <param name="title">Hata mesajı başlık bilgisi</param>
        /// <param name="configure">Konfigürasyon  <see cref="ToastOptions"/> genel ayarlarını içerir</param>
        void Error(string message, string title = null, Action<ToastOptions> configure = null);

        /// <summary>
        /// Ekelencek nesne bilgilerini görüntüler <see cref="ToastType" />
        /// </summary>
        /// <param name="type">Eklenecek nesne tipi <see cref="ToastType"/></param>
        /// <param name="message">Eklenecek nesne mesaj içeriği</param>
        /// <param name="title">Nesne adı</param>
        /// <param name="configure">Konfigürasyon  <see cref="ToastOptions"/> genel ayarlarını içerir</param>
        void Add(ToastType type, string message, string title, Action<ToastOptions> configure);

        /// <summary>
        /// Görüntülenmeyi bekleyenler de dahil olmak üzere tüm toastları gizler
        /// </summary>
        void Clear();

        /// <summary>
        /// Seçilen örnekleri siler veya yaptığınız işleme bağlı gizler <see cref="VedasToast"/>
        /// </summary>
        /// <param name="toast"> <see cref="VedasToast"/> siler veya gizler</param>
        void Remove(VedasToast toast);
    }
}