using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Personel
{
    public partial class DuyuruDetay
    {
        [Inject]
        private IBaseRepository<Yayin> DuyuruServisi { get; set; }

        [Parameter]
        public int DuyuruId { get; set; }

        private Yayin yayinDurum { get; set; }

        protected override Task OnInitializedAsync()
        {
            yayinDurum = DuyuruServisi.Get(DuyuruId);
            return Task.CompletedTask;
        }
    }
}
