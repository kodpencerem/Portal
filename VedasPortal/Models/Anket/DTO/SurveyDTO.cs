﻿using System;
using System.Collections.Generic;
using VedasPortal.Models.Anket.Contracts;

namespace VedasPortal.Models.Anket.DTO
{
    public class SurveyDTO : ISurveyDTO
    {
        public int SurveyId { get; set; }
        public string SurveyName { get; set; }
        public string Description { get; set; }

        public string SurveyQuestion { get; set; }

        public int TotalVotes { get; set; }

        public bool FeaturedSurvey { get; set; }

        public int TotalTimesTaken { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<SurveyOptionDTO> SurveyOptions { get; set; }


    }
}
