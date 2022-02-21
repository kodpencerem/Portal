using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Models.Anket.Contracts;

namespace VedasPortal.Components.Anket
{
    public partial class SurveyCount : ComponentBase
    {

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

   
        [Inject]
        public ISurveyManager SurveyManager { get; set; }

        private int? NumberOfSurveys { get; set; }



        protected override async Task OnParametersSetAsync()
        {
            var surveys = await SurveyManager.GetAllSurveysAsync();

            if (surveys.IsSuccess)
            {
                NumberOfSurveys = surveys.Value.Count();
            }
            else
            {
                NumberOfSurveys = 0;
            }

        }

    }
}
