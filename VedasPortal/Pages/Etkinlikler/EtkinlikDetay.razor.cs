using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Models.Etkinlik;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Etkinlikler
{
    public partial class EtkinlikDetay
    {
        [Inject]
        private IBaseRepository<Etkinlik> EtkinlikServisi { get; set; }

        [Parameter]
        public int EtkinlikId { get; set; }

        private Etkinlik EtkinlikDetayGetir { get; set; }

        protected override Task OnInitializedAsync()
        {
            EtkinlikDetayGetir = EtkinlikServisi.Get(EtkinlikId);
            return Task.CompletedTask;
        }
    }
}
