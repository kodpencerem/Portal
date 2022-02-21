using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VedasPortal.Models.Anket.Models
{
    [Table("Surveys")]
    public class Survey:Base.BaseEntity
    {
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public string Description { get; set; }

        public string SurveyQuestion { get; set; }

        public int TotalVotes { get; set; }

        public bool FeaturedSurvey { get; set; }

        public int TotalTimesTaken { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<SurveyOption> SurveyOptions { get; set; }
    }
}
