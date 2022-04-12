using Microsoft.AspNetCore.Components;
using System;
using VedasPortal.Entities.DTOs.Anket;

namespace VedasPortal.Components.Anket
{
    public partial class AnketSecenekItem : ComponentBase
    {

        [Parameter]
        public AnketSecenekDTO Item { get; set; }

        [Parameter]
        public int ToplamAnketOyu { get; set; }

        private string imageSrc { get; set; }

        private int TotalPercentage { get; set; }

        protected override void OnInitialized()
        {
            imageSrc = $"images/{Item.Resim}";
            double YuzdelikHesapla = 0;
            if (Item.ToplamKatilim != 0)
            {
                YuzdelikHesapla = (double)Item.ToplamKatilim / ToplamAnketOyu * 100;
            }
            TotalPercentage = (int)Math.Floor(YuzdelikHesapla);
        }
    }
}

