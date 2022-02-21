using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Models.Anket.ViewModels
{
    public class SurveyViewModel
    {
        public int SurveyId { get; set; }

        [Required(ErrorMessage = "Anket adı gereklidir!")]
        public string SurveyName { get; set; }
        [Required(ErrorMessage = "Açıklama alanı gereklidir. Boş geçemezsiniz!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Anket sorusu gereklidir!")]
        public string SurveyQuestion { get; set; }

        public int TotalVotes { get; set; }

        public bool FeaturedSurvey { get; set; }

        public int TotalTimesTaken { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "Seçenekleri eklemelisiniz!")]
        public string SelectedOption { get; set; }

        public List<SurveyOptionDTO> SurveyOptions { get; set; } = new List<SurveyOptionDTO>();


        public void SurveyTaken()
        {
            TotalVotes += 1;
            TotalTimesTaken += 1;
        }

        public void TallyVote()
        {
            var selectedValue = int.Parse(SelectedOption);
            var optionSelected = SurveyOptions.Where(x => x.SurveyOptionId == selectedValue).FirstOrDefault();

            optionSelected.TotalVotes += 1;
        }




    }
}
