using System.Collections.Generic;
using System.Linq;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.Models;

namespace VedasPortal.Models.Anket.Utils
{
    public static class Mapper
    {
        public static AnketDTO ToAnketDTO(Models.Anket anket)
        {

            var anketDTO = new AnketDTO()
            {
                AnketId = anket.Id,
                Adi = anket.Adi,
                Aciklama = anket.Aciklama,
                AnketSorusu = anket.AnketSorusu,
                SecilenAnketMi = anket.SecilenAnketMi,
                ToplamKatilim = anket.ToplamKatilim,
                ToplamAlinanSure = anket.ToplamAlinanSure,
                OlusturulmaTarihi = anket.KayitTarihi,
                AnketSecenekleri = ToAnketSecenekList(anket.AnketSecenek)
            };

            return anketDTO;
        }


        public static AnketSecenekDTO ToAnketSecenekDTO(AnketSecenek anketSecenek)
        {
            var secenekDTO = new AnketSecenekDTO()
            {
                AnketSecenekId = anketSecenek.Id,
                Aciklama = anketSecenek.Aciklama,
                Resim = anketSecenek.Resim,
                Fk_AnketId = anketSecenek.Fk_AnketId,
                ToplamKatilim = anketSecenek.ToplamKatilim
            };

            return secenekDTO;
        }

        public static List<AnketSecenekDTO> ToAnketSecenekList(ICollection<AnketSecenek> Secenekler)
        {
            var secenekDTOs = new List<AnketSecenekDTO>();

            foreach (var secenek in Secenekler.ToList())
            {
                secenekDTOs.Add(ToAnketSecenekDTO(secenek));
            }
            return secenekDTOs;
        }

        public static Models.Anket FromAnketDTO(AnketDTO anketDTO)
        {
            var anket = new Models.Anket()
            {
                Id = anketDTO.AnketId,
                Adi = anketDTO.Adi,
                Aciklama = anketDTO.Aciklama,
                AnketSorusu = anketDTO.AnketSorusu,
                SecilenAnketMi = anketDTO.SecilenAnketMi,
                ToplamKatilim = anketDTO.ToplamKatilim,
                ToplamAlinanSure = anketDTO.ToplamAlinanSure,
                KayitTarihi = anketDTO.OlusturulmaTarihi,
                AnketSecenek = FromAnketSecenekList(anketDTO.AnketSecenekleri)
            };

            return anket;
        }


        public static AnketSecenek FromAnketSecenekDTO(AnketSecenekDTO secenekDTO)
        {
            var anketSecenek = new AnketSecenek()
            {
                Id = secenekDTO.AnketSecenekId,
                Aciklama = secenekDTO.Aciklama,
                Resim = secenekDTO.Resim,
                Fk_AnketId = secenekDTO.Fk_AnketId,
                ToplamKatilim = secenekDTO.ToplamKatilim
            };

            return anketSecenek;
        }

        public static List<AnketSecenek> FromAnketSecenekList(List<AnketSecenekDTO> AnketSecenekDTOs)
        {
            var anketSecenekleri = new List<AnketSecenek>();

            foreach (var anketSecenekDTO in AnketSecenekDTOs.ToList())
            {
                anketSecenekleri.Add(FromAnketSecenekDTO(anketSecenekDTO));
            }

            return anketSecenekleri;
        }

        public static List<AnketDTO> ToAnketDTOList(ICollection<Models.Anket> Anketler)
        {
            var anketDTOs = new List<AnketDTO>();

            foreach (var anket in Anketler)
            {
                anketDTOs.Add(ToAnketDTO(anket));
            }

            return anketDTOs;
        }

    }
}
