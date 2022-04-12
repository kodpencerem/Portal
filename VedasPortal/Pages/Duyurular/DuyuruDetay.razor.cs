using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular
{
    public partial class DuyuruDetay
    {
        [Inject]
        private IBaseRepository<HaberDuyuru> DuyuruServisi { get; set; }

        [Parameter]
        public int DuyuruId { get; set; }

        private HaberDuyuru DuyuruDetayGetir { get; set; }

        public Dosya HaberDetayDosya { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            DuyuruDetayGetir = DuyuruServisi.Get(DuyuruId);
            return Task.CompletedTask;
        }
    }
}
