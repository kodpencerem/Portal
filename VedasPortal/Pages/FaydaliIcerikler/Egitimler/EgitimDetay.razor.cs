using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler
{
    public partial class EgitimDetay
    {
        [Inject]
        private IBaseRepository<Egitim> EgitimServisi { get; set; }

        [Parameter]
        public int EgitimId { get; set; }

        protected Egitim EgitimDetayGetir { get; set; }

        protected override Task OnInitializedAsync()
        {
            EgitimDetayGetir = EgitimServisi.Get(EgitimId);
            return Task.CompletedTask;
        }
    }
}
