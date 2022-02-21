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
    public partial class Survey : ComponentBase
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
        public ISurveyManager SurveyManager { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        private SurveyViewModel SurveyVM = new SurveyViewModel();

        private SurveyDTO survey;

        private bool isReady = false;

        protected override async Task OnInitializedAsync()
        {
            var result = await SurveyManager.GetSurveyAsync(Id);

            if (result.IsSuccess)
            {
                survey = result.Value;
                SurveyVM = mapper.SurveyToSurveyViewModel(survey);
            }

            isReady = true;
        }

        private async Task SubmitSurvey()
        {
            var model = SurveyVM;

            SurveyVM.SurveyTaken();
            SurveyVM.TallyVote();

            survey.TotalTimesTaken = SurveyVM.TotalTimesTaken;
            survey.SurveyOptions = SurveyVM.SurveyOptions;
            survey.TotalVotes = SurveyVM.TotalVotes;

            var result = await SurveyManager.UpdateSurveyAsync(survey);

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

        private void UpdateSelectedValue(string selectedOptionId)
        {
            SurveyVM.SelectedOption = selectedOptionId;
        }


    }
}
