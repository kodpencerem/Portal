using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Utils.Anket.CustomValidation;

namespace VedasPortal.Models.Anket.ViewModels
{
    public class EditSurveyViewModel
    {
        public EditSurveyViewModel(VedasDbContext context)
        {
            Context = context;
        }
        public int SurveyId { get; set; }

        [Required(ErrorMessage = "Anket adı gereklidir!")]
        public string SurveyName { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Anket sorusu gereklidir!")]
        [MaxLength(255, ErrorMessage = "Anket sorusu çok uzun!!")]
        public string SurveyQuestion { get; set; }

        public bool FeaturedSurvey { get; set; }

        [RequiredNumberOfSelectItems(RequiredNumberOfRecords = 2, ErrorMessage = "En az 2 seçenek gereklidir!!")]
        public List<SelectListItem> SurveyOptions { get; set; } = new List<SelectListItem>();

        public List<SurveyOptionDTO> SurveyOptionsToAdd { get; set; } = new List<SurveyOptionDTO>();

        public VedasDbContext Context { get; }

        public void AddSurveyOption(SurveyOptionDTO option)
        {
            SelectListItem optionToAdd = new SelectListItem { Selected = false, Text = option.Description, Value = option.SurveyOptionId.ToString() };
            SurveyOptions.Add(optionToAdd);
            SurveyOptionsToAdd.Add(new SurveyOptionDTO()
            {
                Fk_SurveyId = SurveyId,
                Description = option.Description,
                ImagePath = option.ImagePath,
                TotalVotes = 0
            });

        }

        public void RemoveSurveyOption(int optionId)
        {

            string description = SurveyOptions.FirstOrDefault(x => x.Value == optionId.ToString()).Text;

            SurveyOptions.Remove(SurveyOptions.FirstOrDefault(x => x.Value == optionId.ToString()));

            if (SurveyOptionsToAdd.Any(x => x.SurveyOptionId == optionId))
            {
                SurveyOptionsToAdd.Remove(SurveyOptionsToAdd.FirstOrDefault(x => x.SurveyOptionId == optionId));
            }
            else
            {
                SurveyOptionsToAdd.Remove(SurveyOptionsToAdd.FirstOrDefault(x => x.Description == description && x.SurveyOptionId == 0));
            }

        }
    }
}
