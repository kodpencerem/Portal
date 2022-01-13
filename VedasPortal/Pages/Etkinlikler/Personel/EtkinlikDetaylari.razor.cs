using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Services.EtkinlikServisi;

namespace VedasPortal.Pages.Etkinlikler.Personel
{
    public partial class EtkinlikDetaylari
    {
        [Inject]
        private EtkinlikService EtkinlikService { get; set; }

        [Parameter]
        public int EtkinlikId { get; set; }

        private EtkinlikDurum EtkinlikDurum { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EtkinlikDurum = await EtkinlikService.EtkinlikGetir(EtkinlikId);
        }
    }
}
