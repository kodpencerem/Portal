using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.ViewModels;

namespace VedasPortal.Utils.Anket
{
    public class Mapper
    {
        public Mapper(VedasDbContext context)
        {
            Context = context;
        }

        public VedasDbContext Context { get; }

        public Models.Anket.Models.Anket AnketDuzenleToAnket(AnketDuzenleVm duzenleVm)
        {
            Models.Anket.Models.Anket anket = new Models.Anket.Models.Anket()
            {
                Id = duzenleVm.AnketId,
                Adi = duzenleVm.Adi,
                Aciklama = duzenleVm.Aciklama,
                AnketSorusu = duzenleVm.AnketSorusu,
                SecilenAnketMi = duzenleVm.SecilenAnketMi
            };

            return anket;
        }

        public AnketDuzenleVm AnketToAnketDuzenlemeModeli(AnketDTO anketDTO)
        {
            AnketDuzenleVm anketDuzenle = new AnketDuzenleVm(Context)
            {
                AnketId = anketDTO.AnketId,
                Adi = anketDTO.Adi,
                AnketSecenekleri = DuzenlemeModeliOlusturmaVeListeleme(anketDTO.AnketSecenekleri.ToList()),
                AnketSorusu = anketDTO.AnketSorusu,
                SecilenAnketMi = anketDTO.SecilenAnketMi,
                Aciklama = anketDTO.Aciklama,
                AnketSecenekEkle = anketDTO.AnketSecenekleri
            };

            return anketDuzenle;
        }

        public AnketVm AnketToAnketVm(AnketDTO anketDTO)
        {
            var results = new AnketVm()
            {
                AnketId = anketDTO.AnketId,
                Adi = anketDTO.Adi,
                AnketSecenekleri = anketDTO.AnketSecenekleri.ToList(),
                AnketSorusu = anketDTO.AnketSorusu,
                OlusturulmaTarihi = anketDTO.OlusturulmaTarihi,
                ToplamAlinanSure = anketDTO.ToplamAlinanSure,
                ToplamKatilim = anketDTO.ToplamKatilim,
                Aciklama = anketDTO.Aciklama,
                SecilenAnketMi = anketDTO.SecilenAnketMi

            };

            return results;
        }

        private List<SelectListItem> DuzenlemeModeliOlusturmaVeListeleme(List<AnketSecenekDTO> AnketSecenekDTO)
        {
            List<SelectListItem> secilenListe = new List<SelectListItem>();


            foreach (var anketSecenek in AnketSecenekDTO)
            {
                secilenListe.Add(new SelectListItem { Text = anketSecenek.Aciklama, Selected = false, Value = anketSecenek.AnketSecenekId.ToString() });

            }

            return secilenListe;
        }
    }
}

