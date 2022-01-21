using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz.Personel
{
    public partial class HaberDetay
    {
        [Inject]
        private IBaseRepository<Yayin> HaberServisi { get; set; }

        [Parameter]
        public int HaberId { get; set; }

        private Yayin yayinDurum { get; set; }

        protected override Task OnInitializedAsync()
        {
            yayinDurum = HaberServisi.Get(HaberId);
            return Task.CompletedTask;
        }
    }
}
