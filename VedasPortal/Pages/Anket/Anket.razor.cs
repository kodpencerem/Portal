using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.ViewModels;
using VedasPortal.Utils.Anket;

namespace VedasPortal.Pages.Anket
{
    public partial class Anket : ComponentBase
    {


        [Parameter]
        public int Id { get; set; }

        [Inject]
        public VedasDbContext Context { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public Mapper mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        private AnketVm AnketVm = new AnketVm();

        private AnketDTO AnketDTO;

        private bool isReady = false;

        protected override async Task OnInitializedAsync()
        {
            var result = await AnketYonetim.AnketGetirAsync(Id);

            if (result.IsSuccess)
            {
                AnketDTO = result.Value;
                AnketVm = mapper.AnketToAnketVm(AnketDTO);
            }

            isReady = true;
        }

        private async Task AnketGonder()
        {
            var model = AnketVm;

            AnketVm.YapilanAnket();
            AnketVm.SonucAl();

            AnketDTO.ToplamAlinanSure = AnketVm.ToplamAlinanSure;
            AnketDTO.AnketSecenekleri = AnketVm.AnketSecenekleri;
            AnketDTO.ToplamKatilim = AnketVm.ToplamKatilim;

            var result = await AnketYonetim.AnketDuzenleAsync(AnketDTO);

            if (result.IsSuccess)
            {
                ToastService.ShowInfo("Ankete katılımınız için teşekkür ederiz.", "Teşekkürler");

                NavigationManager.NavigateTo("/");
            }
            else
            {
                ToastService.ShowError("Bir hata ile karşılaşıldı!", "");
            }

        }

        private void SecilenDegeriGuncelle(string secilmisSecenekId)
        {
            AnketVm.SecilenSecenek = secilmisSecenekId;
        }


    }
}
