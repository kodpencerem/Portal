using System.Collections.Generic;
using System.Linq;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.Models;

namespace VedasPortal.Models.Anket.Utils
{
    public static class Mapper
    {
        public static AnketDTO ToSurveyDTO(Models.Anket survey)
        {

            var result = new AnketDTO()
            {
                AnketId = survey.Id,
                Adi = survey.Adi,
                Aciklama = survey.Aciklama,
                AnketSorusu = survey.AnketSorusu,
                SecilenAnketMi = survey.SecilenAnketMi,
                ToplamKatilim = survey.ToplamKatilim,
                ToplamAlinanSure = survey.ToplamAlinanSure,
                OlusturulmaTarihi = survey.KayitTarihi,
                AnketSecenekleri = ToSurveyOptionList(survey.AnketSecenek)
            };

            return result;
        }


        public static AnketSecenekDTO ToSurveyOptionDTO(AnketSecenek option)
        {
            var result = new AnketSecenekDTO()
            {
                AnketSecenekId = option.Id,
                Aciklama = option.Aciklama,
                Resim = option.Resim,
                Fk_AnketId = option.Fk_AnketId,
                ToplamKatilim = option.ToplamKatilim
            };

            return result;
        }

        public static List<AnketSecenekDTO> ToSurveyOptionList(ICollection<AnketSecenek> options)
        {
            var result = new List<AnketSecenekDTO>();

            foreach (var option in options.ToList())
            {
                result.Add(ToSurveyOptionDTO(option));
            }

            return result;
        }

        public static Models.Anket FromSurveyDTO(AnketDTO survey)
        {
            var result = new Models.Anket()
            {
                Id = survey.AnketId,
                Adi = survey.Adi,
                Aciklama = survey.Aciklama,
                AnketSorusu = survey.AnketSorusu,
                SecilenAnketMi = survey.SecilenAnketMi,
                ToplamKatilim = survey.ToplamKatilim,
                ToplamAlinanSure = survey.ToplamAlinanSure,
                KayitTarihi = survey.OlusturulmaTarihi,
                AnketSecenek = FromSurveyOptionList(survey.AnketSecenekleri)
            };

            return result;
        }


        public static AnketSecenek FromSurveyOptionDTO(AnketSecenekDTO option)
        {
            var result = new AnketSecenek()
            {
                Id = option.AnketSecenekId,
                Aciklama = option.Aciklama,
                Resim = option.Resim,
                Fk_AnketId = option.Fk_AnketId,
                ToplamKatilim = option.ToplamKatilim
            };

            return result;
        }

        public static List<AnketSecenek> FromSurveyOptionList(List<AnketSecenekDTO> options)
        {
            var result = new List<AnketSecenek>();

            foreach (var option in options.ToList())
            {
                result.Add(FromSurveyOptionDTO(option));
            }

            return result;
        }

        public static List<AnketDTO> ToSurveyDTOList(ICollection<Models.Anket> surveys)
        {
            var result = new List<AnketDTO>();

            foreach (var survey in surveys)
            {
                result.Add(ToSurveyDTO(survey));
            }

            return result;
        }

    }
}
