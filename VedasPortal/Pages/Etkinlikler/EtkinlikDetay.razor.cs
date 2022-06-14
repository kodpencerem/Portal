using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Etkinlikler
{
    public partial class EtkinlikDetay
    {
        [Inject]
        private IBaseRepository<Etkinlik> EtkinlikServisi { get; set; }

        [Parameter]
        public int EtkinlikId { get; set; }

        public ImageFile EtkinlikDetayDosya { get; set; } = new();

        private Etkinlik etkinlik { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            etkinlik = EtkinlikServisi.Get(EtkinlikId);
            return Task.CompletedTask;
        }

        [Inject]
        public IJSRuntime JsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("lightGallery");
            }
        }
    }
}
