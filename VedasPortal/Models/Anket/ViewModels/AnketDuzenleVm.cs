using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Utils.Anket.CustomValidation;

namespace VedasPortal.Models.Anket.ViewModels
{
    public class AnketDuzenleVm
    {
        public AnketDuzenleVm(VedasDbContext context)
        {
            Context = context;
        }
        public int AnketId { get; set; }

        [Required(ErrorMessage = "Anket adı gereklidir!")]
        public string Adi { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir!")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Anket sorusu gereklidir!")]
        [MaxLength(255, ErrorMessage = "Anket sorusu çok uzun!!")]
        public string AnketSorusu { get; set; }

        public bool SecilenAnketMi { get; set; }

        [SecilmisGerekliOgelerSayisi(GerekliKayitSayisi  = 2, ErrorMessage = "En az 2 seçenek gereklidir!!")]
        public List<SelectListItem> AnketSecenekleri { get; set; } = new List<SelectListItem>();

        public List<AnketSecenekDTO> AnketSecenekEkle { get; set; } = new List<AnketSecenekDTO>();

        public VedasDbContext Context { get; }

        public void AnketSecenekleriEkle(AnketSecenekDTO secenekDTO)
        {
            SelectListItem SecenekEkle = new SelectListItem { Selected = false, Text = secenekDTO.Aciklama, Value = secenekDTO.AnketSecenekId.ToString() };
            AnketSecenekleri.Add(SecenekEkle);
            AnketSecenekEkle.Add(new AnketSecenekDTO()
            {
                Fk_AnketId = AnketId,
                Aciklama = secenekDTO.Aciklama,
                Resim = secenekDTO.Resim,
                ToplamKatilim = 0
            });

        }

        public void AnketSecenekSil(int secenekId)
        {

            string Aciklama = AnketSecenekleri.FirstOrDefault(x => x.Value == secenekId.ToString()).Text;

            AnketSecenekleri.Remove(AnketSecenekleri.FirstOrDefault(x => x.Value == secenekId.ToString()));

            if (AnketSecenekEkle.Any(x => x.AnketSecenekId == secenekId))
            {
                AnketSecenekEkle.Remove(AnketSecenekEkle.FirstOrDefault(x => x.AnketSecenekId == secenekId));
            }
            else
            {
                AnketSecenekEkle.Remove(AnketSecenekEkle.FirstOrDefault(x => x.Aciklama == Aciklama && x.AnketSecenekId == 0));
            }

        }
    }
}
