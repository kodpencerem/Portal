using Ardalis.Result;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Repository.Interface.Anket;

namespace VedasPortal.Components.Anket
{
    public partial class SecilmisAnket : ComponentBase
    {
        [Inject]
        IAnketYonetim AnketYonetim { get; set; }

        private IAnketDTO Anket = null;

        [Inject]
        public IToastService ToastService { get; set; }

        private bool isReady = false;

        [Parameter]
        public int AnketId { get; set; }


        private void AnketiGetir(int anketId)
        {
            NavigationManager.NavigateTo($"anket/{anketId}");
        }

        public async Task TakeRandomSurvey()
        {
            var result = await AnketYonetim.RastGeleAnketGetirAsync();


            if (result.IsSuccess)
            {
                NavigationManager.NavigateTo($"anket/{result.Value.AnketId}");
            }
            else if (result.Status == ResultStatus.NotFound)
            {
                ToastService.ShowInfo("Şu anda mevcut anket yok!");
            }
            else
            {
                ToastService.ShowError("Şu anda rastgele anket alınamıyor!", "");
            }

        }

        protected override async Task OnInitializedAsync()
        {
            if (AnketId != 0)
            {

                var result = await AnketYonetim.AnketGetirAsync(AnketId);

                if (result.IsSuccess)
                {
                    Anket = result.Value;
                }
            }
            else
            {

                var result = await AnketYonetim.RastGeleAnketGetirAsync();

                if (result.IsSuccess)
                {
                    Anket = result.Value;
                }

                if (result.Status == ResultStatus.NotFound)
                {
                    Anket = null;
                }

            }


            isReady = true;
        }

    }
}
