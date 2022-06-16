using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Entities.ViewModels.Anket
{
    public class AnketSecenekVm
    {
        public int AnketSecenekId { get; set; }
        public int Fk_AnketId { get; set; }
        [Required(ErrorMessage = "Açıklama gereklidir. Boş geçemezsiniz!")]
        public string Aciklama { get; set; }
        public string Resim { get; set; } = "default.jpg";
        public int ToplamKatilim { get; set; } = 0;
    }
}