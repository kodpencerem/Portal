using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Models.Anket.ViewModels
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

        public int ToplamKatilim { get; set; }

        public bool SecilenAnketMi { get; set; }

        public int ToplamAlinanSure { get; set; }

        public DateTime OlusturulmaTarihi { get; set; }

        [Required(ErrorMessage = "Seçenekleri eklemelisiniz!")]
        public string SecilenSecenek { get; set; }

        public List<AnketSecenekDTO> AnketSecenekleri { get; set; } = new List<AnketSecenekDTO>();


        public void SurveyTaken()
        {
            ToplamKatilim += 1;
            ToplamAlinanSure += 1;
        }

        public void TallyVote()
        {
            var selectedValue = int.Parse(SecilenSecenek);
            var optionSelected = AnketSecenekleri.Where(x => x.AnketSecenekId == selectedValue).FirstOrDefault();

            optionSelected.ToplamKatilim += 1;
        }




    }
}
