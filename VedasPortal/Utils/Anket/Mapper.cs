using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.Models;
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

        public Survey EditSurveyToSurvey(EditSurveyViewModel survey)
        {
            Survey result = new Survey()
            {
                SurveyId = survey.SurveyId,
                SurveyName = survey.SurveyName,
                Description = survey.Description,
                SurveyQuestion = survey.SurveyQuestion,
                FeaturedSurvey = survey.FeaturedSurvey
            };

            return result;
        }

        public EditSurveyViewModel SurveyToEditSurveyModel(SurveyDTO survey)
        {
            EditSurveyViewModel results = new EditSurveyViewModel(Context)
            {
                SurveyId = survey.SurveyId,
                SurveyName = survey.SurveyName,
                SurveyOptions = GenerateEditViewModelOptionSelectList(survey.SurveyOptions.ToList()),
                SurveyQuestion = survey.SurveyQuestion,
                FeaturedSurvey = survey.FeaturedSurvey,
                Description = survey.Description,
                SurveyOptionsToAdd = survey.SurveyOptions
            };

            return results;
        }

        public SurveyViewModel SurveyToSurveyViewModel(SurveyDTO survey)
        {
            var results = new SurveyViewModel()
            {
                SurveyId = survey.SurveyId,
                SurveyName = survey.SurveyName,
                SurveyOptions = survey.SurveyOptions.ToList(),
                SurveyQuestion = survey.SurveyQuestion,
                CreatedOn = survey.CreatedOn,
                TotalTimesTaken = survey.TotalTimesTaken,
                TotalVotes = survey.TotalVotes,
                Description = survey.Description,
                FeaturedSurvey = survey.FeaturedSurvey

            };

            return results;
        }

        private List<SelectListItem> GenerateEditViewModelOptionSelectList(List<SurveyOptionDTO> options)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();


            foreach (var surveyOption in options)
            {
                selectList.Add(new SelectListItem { Text = surveyOption.Description, Selected = false, Value = surveyOption.SurveyOptionId.ToString() });

            }

            return selectList;
        }
    }
}

