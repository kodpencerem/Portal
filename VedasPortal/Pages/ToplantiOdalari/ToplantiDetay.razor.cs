using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari
{
    public partial class ToplantiDetay
    {
        [Inject]
        private IBaseRepository<Toplanti> ToplantiServisi { get; set; }

        [Parameter]
        public int ToplantiId { get; set; }

        private Toplanti ToplantiGetir { get; set; }

        protected override Task OnInitializedAsync()
        {
            ToplantiGetir = ToplantiServisi.Get(ToplantiId);
            return Task.CompletedTask;
        }
    }
}
