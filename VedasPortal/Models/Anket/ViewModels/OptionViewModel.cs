using System.ComponentModel.DataAnnotations;

namespace VedasPortal.Models.Anket.ViewModels
{
    public class OptionViewModel
    {
        public int SurveyOptionId { get; set; }

        public int Fk_SurveyId { get; set; }

        [Required(ErrorMessage = "Açıklama gereklidir. Boş geçemezsiniz!rg")]
        public string Description { get; set; }

        public string ImagePath { get; set; } = "default.jpg";
        public int TotalVotes { get; set; } = 0;
    }
}
