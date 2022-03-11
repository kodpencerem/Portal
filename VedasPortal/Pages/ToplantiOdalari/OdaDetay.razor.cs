using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari
{
    public partial class OdaDetay
    {
        [Inject]
        private IBaseRepository<ToplantiOdasi> ToplantiOdasi { get; set; }

        [Parameter]
        public int OdaId { get; set; }

        private ToplantiOdasi OdaDetayGetir { get; set; }

        protected override Task OnInitializedAsync()
        {
            OdaDetayGetir = ToplantiOdasi.Get(OdaId);
            return Task.CompletedTask;
        }
    }
}
