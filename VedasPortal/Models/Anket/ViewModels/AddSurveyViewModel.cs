using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Utils.Anket.CustomValidation;

namespace VedasPortal.Models.Anket.ViewModels
{
    public class AddSurveyViewModel
    {

        #region Properties
        [Required(ErrorMessage = "Anket adı gereklidir!")]
        public string SurveyName { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Anket sorusu gereklidir!")]
        public string SurveyQuestion { get; set; }

        public List<SelectListItem> SurveyOptions { get; set; } = new List<SelectListItem>() { };

        [RequiredNumberOfItems(RequiredNumberOfRecords = 2, ErrorMessage = "En az 2 seçenek gereklidir!")]
        public List<SurveyOptionDTO> SurveyOptionsToAdd { get; set; } = new List<SurveyOptionDTO>();

        public VedasDbContext Context { get; }
        public int MaxSurveyOptionId { get; set; }

        public bool FeaturedSurvey { get; set; }


        #endregion


        #region Methods

        public SurveyDTO GenerateSurveyToSave()
        {
            return new SurveyDTO()
            {
                SurveyName = SurveyName,
                Description = Description,
                SurveyQuestion = SurveyQuestion,
                FeaturedSurvey = FeaturedSurvey,
                TotalVotes = 0,
                TotalTimesTaken = 0,
                CreatedOn = DateTime.Now,
                SurveyOptions = SurveyOptionsToAdd
            };
        }
        public void AddSurveyOption(SurveyOptionDTO option, int maxId)
        {
            SelectListItem optionToAdd = new SelectListItem { Selected = false, Text = option.Description, Value = maxId.ToString() };
            SurveyOptions.Add(optionToAdd);


        }

        public void RemoveSurveyOption(int optionId)
        {
            string description = SurveyOptions.FirstOrDefault(x => x.Value == optionId.ToString()).Text;

            SurveyOptionsToAdd.Remove(SurveyOptionsToAdd.FirstOrDefault(x => x.Description == description));

            SurveyOptions.Remove(SurveyOptions.FirstOrDefault(x => x.Value == optionId.ToString()));


        }

        public int GetMaxId()
        {
            var maxId = SurveyOptions.Count == 0 ? 0 : int.Parse(SurveyOptions.OrderByDescending(x => x.Value).FirstOrDefault().Value);
            maxId = maxId += 1;
            return maxId;
        }
        #endregion


    }
}
