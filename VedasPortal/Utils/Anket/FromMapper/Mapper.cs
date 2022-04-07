using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Entities.DTOs.Anket;
using VedasPortal.Entities.ViewModels.Anket;

namespace VedasPortal.Utils.Anket.FromMapper
{
    public class Mapper
    {
        public Mapper(VedasDbContext context)
        {
            Context = context;
        }
        public VedasDbContext Context { get; }
        public Entities.Models.Anket.Anket AnketDuzenleToAnket(AnketDuzenleVm duzenleVm)
        {
            Entities.Models.Anket.Anket anket = new()
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
            AnketDuzenleVm anketDuzenle = new(Context)
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
            List<SelectListItem> secilenListe = new();
            foreach (var anketSecenek in AnketSecenekDTO)
            {
                secilenListe.Add(new SelectListItem 
                { 
                    Text = anketSecenek.Aciklama, 
                    Selected = false, 
                    Value = anketSecenek.AnketSecenekId.ToString() });

            }
            return secilenListe;
        }
    }
}