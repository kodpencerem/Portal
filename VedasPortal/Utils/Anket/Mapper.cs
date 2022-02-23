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

        public Models.Anket.Models.Anket EditSurveyToSurvey(AnketDuzenleVm survey)
        {
            Models.Anket.Models.Anket result = new Models.Anket.Models.Anket()
            {
                Id = survey.AnketId,
                Adi = survey.Adi,
                Aciklama = survey.Aciklama,
                AnketSorusu = survey.AnketSorusu,
                SecilenAnketMi = survey.SecilenAnketMi
            };

            return result;
        }

        public AnketDuzenleVm SurveyToEditSurveyModel(AnketDTO survey)
        {
            AnketDuzenleVm results = new AnketDuzenleVm(Context)
            {
                AnketId = survey.AnketId,
                Adi = survey.Adi,
                AnketSecenekleri = GenerateEditViewModelOptionSelectList(survey.AnketSecenekleri.ToList()),
                AnketSorusu = survey.AnketSorusu,
                SecilenAnketMi = survey.SecilenAnketMi,
                Aciklama = survey.Aciklama,
                AnketSecenekEkle = survey.AnketSecenekleri
            };

            return results;
        }

        public AnketVm SurveyToSurveyViewModel(AnketDTO survey)
        {
            var results = new AnketVm()
            {
                AnketId = survey.AnketId,
                Adi = survey.Adi,
                AnketSecenekleri = survey.AnketSecenekleri.ToList(),
                AnketSorusu = survey.AnketSorusu,
                OlusturulmaTarihi = survey.OlusturulmaTarihi,
                ToplamAlinanSure = survey.ToplamAlinanSure,
                ToplamKatilim = survey.ToplamKatilim,
                Aciklama = survey.Aciklama,
                SecilenAnketMi = survey.SecilenAnketMi

            };

            return results;
        }

        private List<SelectListItem> GenerateEditViewModelOptionSelectList(List<AnketSecenekDTO> options)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();


            foreach (var surveyOption in options)
            {
                selectList.Add(new SelectListItem { Text = surveyOption.Aciklama, Selected = false, Value = surveyOption.AnketSecenekId.ToString() });

            }

            return selectList;
        }
    }
}

