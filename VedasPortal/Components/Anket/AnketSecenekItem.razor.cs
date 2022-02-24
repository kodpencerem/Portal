using Microsoft.AspNetCore.Components;
using System;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Components.Anket
{
    public partial class AnketSecenekItem : ComponentBase
    {

        [Parameter]
        public AnketSecenekDTO Item { get; set; }

        [Parameter]
        public int TotalSurveyVotes { get; set; }

        private string imageSrc { get; set; }

        private int TotalPercentage { get; set; }

        protected override void OnInitialized()
        {
            imageSrc = $"images/{Item.Resim}";
            double calculatedPercentage = 0;
            if (Item.ToplamKatilim != 0)
            {
                calculatedPercentage = (double)Item.ToplamKatilim / TotalSurveyVotes * 100;
            }

            TotalPercentage = (int)Math.Floor(calculatedPercentage);
        }
    }
}

