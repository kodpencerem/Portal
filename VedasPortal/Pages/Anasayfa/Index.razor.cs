using Ardalis.Result;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Repository.Interface.Anket;

namespace VedasPortal.Pages.Anasayfa
{
    public partial class Index : ComponentBase
    {

        //[Inject]
        //public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IAnketYonetim SurveyManager { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }


        public async Task TakeRandomSurvey()
        {
            var result = await SurveyManager.RastGeleAnketGetirAsync();


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

        public void ViewSurveys()
        {
            NavigationManager.NavigateTo("Anketler");
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

        }

    }
}
