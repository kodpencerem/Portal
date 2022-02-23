using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Models.Anket.ViewModels
{
    public class AnketSecenekVm
    {
        public int AnketSecenekId { get; set; }

        public int Fk_AnketId { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir. Boş geçemezsiniz!rg")]
        public string Aciklama { get; set; }

        public string Resim { get; set; } = "default.jpg";
        public int ToplamKatilim { get; set; } = 0;
    }
}
