using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar
{
    public partial class DokumanDetay
    {
        [Inject]
        private IBaseRepository<ImageFile> HaberServisi { get; set; }

        [Parameter]
        public int DosyaId { get; set; }

        protected ImageFile GetDosya { get; set; }

        protected override Task OnInitializedAsync()
        {
            GetDosya = HaberServisi.Get(DosyaId);
            return Task.CompletedTask;
        }
    }
}
