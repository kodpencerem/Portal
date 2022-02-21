using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Components.Anket
{
    public partial class MostPopularSurvey : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public ISurveyManager SurveyManager { get; set; }
       
        private int? TotalTimesTaken { get; set; }

        private string MostPopularSurveyName { get; set; }

        private SurveyDTO Survey { get; set; }


        protected override async Task OnParametersSetAsync()
        {
            var result = await SurveyManager.GetMostPopularSurveyAsync();

            if (result.IsSuccess)
            {
                Survey = result.Value;
            }

        }
    }
}
