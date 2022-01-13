using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Services.EtkinlikServisi;

namespace VedasPortal.Pages.Etkinlikler.Personel
{
    public partial class Etkinlikler
    {
        [Inject]
        private EtkinlikService EtkinlikService { get; set; }
        private List<EtkinlikDurum> EtkinlikDurum { get; set; }

        protected override async Task OnInitializedAsync()
        {
            EtkinlikDurum = await EtkinlikService.TumEtkinlikleriGetir();
        }
    }
}
