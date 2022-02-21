using Ardalis.Result;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;

namespace VedasPortal.Components.Anket
{
    public partial class FeaturedSurvey : ComponentBase
    {


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        ISurveyManager SurveyManager { get; set; }

        private ISurveyDTO Survey = null;

        private bool isReady = false;

        [Parameter]
        public int SurveyId { get; set; }


        private async Task TakeSurvey(int surveyId)
        {
            NavigationManager.NavigateTo($"survey/{surveyId}");
        }

        protected override async Task OnInitializedAsync()
        {
            if (SurveyId != 0)
            {

                var result = await SurveyManager.GetSurveyAsync(SurveyId);

                if (result.IsSuccess)
                {
                    Survey = result.Value;
                }
            }
            else
            {

                var result = await SurveyManager.GetRandomSurveyAsync();

                if (result.IsSuccess)
                {
                    Survey = result.Value;
                }

                if (result.Status == ResultStatus.NotFound)
                {
                    Survey = null;
                }

            }


            isReady = true;
        }

    }
}
