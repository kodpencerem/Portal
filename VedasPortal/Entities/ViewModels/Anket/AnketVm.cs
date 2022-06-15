using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Entities.DTOs.Anket;

namespace VedasPortal.Entities.ViewModels.Anket
{
    public class AnketVm
    {
        public int AnketId { get; set; }

        [Required(ErrorMessage = "Anket adı gereklidir!")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "Açıklama alanı gereklidir. Boş geçemezsiniz!")]
        public string Aciklama { get; set; }
        [Required(ErrorMessage = "Anket sorusu gereklidir!")]
        public string AnketSorusu { get; set; }
        public string Mesaj { get; set; }
        public int ToplamKatilim { get; set; }
        public bool SecilenAnketMi { get; set; }
        public int ToplamAlinanSure { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        [Required(ErrorMessage = "Seçenekleri eklemelisiniz!")]
        public string SecilenSecenek { get; set; }
        public List<AnketSecenekDTO> AnketSecenekleri { get; set; } = new List<AnketSecenekDTO>();
        public void YapilanAnket()
        {
            if (ToplamKatilim == 0)
            {
                ToplamKatilim += 1;
                ToplamAlinanSure += 1;
            } else if (ToplamKatilim != 0)
            {
                Mesaj = "Zaten Daha Önce Katılımınız Alınmıştır!";
            }
        }
        /// <summary>
        /// Parça parça gelen anket katılım sayısı alır ve ekler
        /// </summary>
        public void SonucAl()
        {
            var secilenDeger = int.Parse(SecilenSecenek);
            var secilenSecenek = AnketSecenekleri.Where(x => x.AnketSecenekId == secilenDeger).FirstOrDefault();
            if (secilenSecenek.ToplamKatilim == 0)
            {
                secilenSecenek.ToplamKatilim += 1;
            }else if (secilenSecenek.ToplamKatilim != 0)
            {
                Mesaj = "Zaten Daha Önce Katılımınız Alınmıştır!";
            }
            
        }
    }
}