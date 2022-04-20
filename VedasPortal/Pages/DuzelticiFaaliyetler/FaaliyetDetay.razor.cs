using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.DuzelticiFaaliyetler
{
    public partial class FaaliyetDetay
    {
        [Inject]
        private IBaseRepository<DuzelticiFaaliyet> DofServisi { get; set; }

        [Parameter]
        public int dFaaliyetId { get; set; }

        private DuzelticiFaaliyet DofDetayGetir { get; set; }

        public Dosya DofDetayDosya { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            DofDetayGetir = DofServisi.Get(dFaaliyetId);
            return Task.CompletedTask;
        }
    }
}
