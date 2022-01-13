using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Services.DuyuruHaber;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {
        [Inject]
        protected DuyuruHaberService DuyuruHaberService { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public int duyuruId { get; set; }

        private string ImageBase64String { get; set; }
        private string PreviewImagePath { get; set; }

        protected string Title = "Ekle";
        public Yayin duyuru = new Yayin();

        protected override async Task OnParametersSetAsync()
        {
            if (duyuruId != 0)
            {
                Title = "Duzenle";
                duyuru = await DuyuruHaberService.DetayGetir(duyuruId);
            }
        }

        protected async Task DuyuruKayit()
        {
            if (duyuru.Id != 0)
            {
                await Task.Run(() =>
                {
                    DuyuruHaberService.Duzenle(duyuru);
                });
            }
            else
            {
                await Task.Run(() =>
                {
                    DuyuruHaberService.Ekle(duyuru);
                });
            }

            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/duyurulistele");
        }
    }
}
