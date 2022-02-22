using Ardalis.Result;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Models.Anket.Contracts;

namespace VedasPortal.Components.Anket
{
    public partial class SecilmisAnket : ComponentBase
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


        private void TakeSurvey(int surveyId)
        {
            NavigationManager.NavigateTo($"anket/{surveyId}");
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
