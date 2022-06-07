﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Etkinlikler
{
    public partial class EtkinlikDetay
    {
        [Inject]
        private IBaseRepository<Etkinlik> EtkinlikServisi { get; set; }

        [Parameter]
        public int EtkinlikId { get; set; }

        public Dosya EtkinlikDetayDosya { get; set; } = new();

        private Etkinlik etkinlik { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            etkinlik = EtkinlikServisi.Get(EtkinlikId);
            return Task.CompletedTask;
        }
    }
}
