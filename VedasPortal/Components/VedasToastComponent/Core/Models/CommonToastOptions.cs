namespace VedasPortal.Components.VedasToastComponent.Core.Models
{
    public abstract class CommonToastOptions
    {
        /// <summary>
        /// Toast sınıfı. Default sınıfından bir nesne referans alır.  <see cref="CheckBoxRadioBase.Classes.Toast"/>
        /// </summary>
        public string ToastClass { get; set; } = CheckBoxRadioBase.Classes.Toast;

        /// <summary>
        /// Bu değişken başlık ve mesaj için geçerlidir. false ise, oluşturulan HTML gösterilecektir, aksi takdirde, kaçan HTML işaretlemesi gösterilecektir.
        /// </summary>
        public bool EscapeHtml { get; set; } = true;

        /// <summary>
        /// Nesne başlık bilgisini döndürür. Defaults sınıfından referans alır. <see cref="CheckBoxRadioBase.Classes.ToastTitle"/>.
        /// </summary>
        public string ToastTitleClass { get; set; } = CheckBoxRadioBase.Classes.ToastTitle;

        /// <summary>
        /// Nesne mesaj içeriğini döndürür. Defaults sınıfından referans alır. <see cref="CheckBoxRadioBase.Classes.ToastMessage"/>.
        /// </summary>
        public string ToastMessageClass { get; set; } = CheckBoxRadioBase.Classes.ToastMessage;

        /// <summary>
        /// Görünür durumda bir toast için tamsayı yüzdesi olarak ifade edilen maksimum opaklık. 0'ın tamamen gizli ve 100'ün düz renk anlamına geldiği durumlarda, varsayılan değer %80'dir.
        /// </summary>
        public int MaximumOpacity { get; set; } = 80;

        /// <summary>
        /// Gösterilen geçişin MaximumOpacity'ye bir toast getirmesi ve onu görünür durumuna ayarlaması süresini ayarlar. Varsayılan olarak 1000 ms'dir.
        /// </summary>
        public int ShowTransitionDuration { get; set; } = 1000;

        /// <summary>
        /// VisibleStateDuration, kullanıcı etkileşimi olmadan ne kadar süre görünür kalır. 1'den küçük bir değer, hemen gizlemeyi tetikler. Varsayılan olarak 5000 ms'dir.
        /// </summary>
        public int VisibleStateDuration { get; set; } = 5000;

        /// <summary>
        /// Bir HideTransitionDuration ortadan kaldırmak için gizleme geçişinin ne kadar sürdüğünü ayarlar. Varsayılan olarak 2000 ms'dir.
        /// </summary>
        public int HideTransitionDuration { get; set; } = 2000;

        /// <summary>
        /// ShowProgressBar görünür durumu sırasında bir ilerleme çubuğunun gösterilmesi gerekip gerekmediğini belirtir.Varsayılan olarak true olur.
        /// </summary>
        public bool ShowProgressBar { get; set; } = true;

        /// <summary>
        ///ProgressBarClass için Defaults sınından bir referans alır . <see cref="CheckBoxRadioBase.Classes.ProgressBarClass"/>.
        /// </summary>
        public string ProgressBarClass { get; set; } = CheckBoxRadioBase.Classes.ProgressBarClass;

        /// <summary>
        /// Bir nesneyi gizlemek için kapat simgesinin kullanılması gerekip gerekmediğini belirtir. Simge varlığı, varsayılan "tıklamada gizle" davranışını devre dışı bırakır. Varsayılan olarak true olur.
        /// </summary>
        public bool ShowCloseIcon { get; set; } = true;

        /// <summary>
        /// Defaults sınıfından örnek alır. <see cref="CheckBoxRadioBase.Classes.CloseIconClass"/>.
        /// </summary>
        public string CloseIconClass { get; set; } = CheckBoxRadioBase.Classes.CloseIconClass;

        /// <summary>
        ///Doğru olduğunda, otomatik gizlemeyi devre dışı bırakır ve kullanıcıyı kapatmak için RequireInteraction ile etkileşime girmeye zorlar.Varsayılan olarak false olur.
        /// </summary>
        public bool RequireInteraction { get; set; } = false;
    }
}
