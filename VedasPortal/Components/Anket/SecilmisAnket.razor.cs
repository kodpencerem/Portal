using Ardalis.Result;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Repository.Interface.Anket;

namespace VedasPortal.Components.Anket
{
    public partial class SecilmisAnket : ComponentBase
    {


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        IAnketYonetim AnketYonetim { get; set; }

        private IAnketDTO Anket = null;

        private bool isReady = false;

        [Parameter]
        public int AnketId { get; set; }


        private void AnketiGetir(int anketId)
        {
            NavigationManager.NavigateTo($"anket/{anketId}");
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
