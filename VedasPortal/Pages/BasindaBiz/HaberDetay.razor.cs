using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz
{
    public partial class HaberDetay
    {
        [Inject]
        private IBaseRepository<HaberDuyuru> HaberServisi { get; set; }

        [Parameter]
        public int HaberId { get; set; }

        private HaberDuyuru HaberDetayGetir { get; set; }

        protected override Task OnInitializedAsync()
        {
            HaberDetayGetir = HaberServisi.Get(HaberId);
            return Task.CompletedTask;
        }
    }
}
