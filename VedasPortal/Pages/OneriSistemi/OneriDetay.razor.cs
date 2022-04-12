using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.OneriSistemi
{
    public partial class OneriDetay
    {
        [Inject]
        private IBaseRepository<Oneri> Oneri { get; set; }

        [Parameter]
        public int OneriId { get; set; }
        public Dosya OneriDetayDosya { get; set; }
        private Oneri OneriDetayGetir { get; set; }

        protected override Task OnInitializedAsync()
        {
            OneriDetayGetir = Oneri.Get(OneriId);
            return Task.CompletedTask;
        }
    }
}
