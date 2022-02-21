﻿using Microsoft.AspNetCore.Components;
using System;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Components.Anket
{
    public partial class SurveyOptionItem : ComponentBase
    {

        [Parameter]
        public SurveyOptionDTO Item { get; set; }

        [Parameter]
        public int TotalSurveyVotes { get; set; }

        private string imageSrc { get; set; }

        private int totalPercentage { get; set; }

        protected override void OnInitialized()
        {
            imageSrc = $"images/{Item.ImagePath}";
            double calculatedPercentage = 0;
            if (Item.TotalVotes != 0)
            {
                calculatedPercentage = (double)Item.TotalVotes / TotalSurveyVotes * 100;
            }

            totalPercentage = (int)Math.Floor(calculatedPercentage);
        }
    }
}

