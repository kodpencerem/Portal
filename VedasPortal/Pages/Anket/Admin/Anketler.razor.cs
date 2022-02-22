using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.Anket.Modals;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Pages.Anket
{
    public partial class AdminSurveyList : ComponentBase
    {

        [Inject]
        public VedasDbContext Context { get; set; }

        [CascadingParameter]
        IModalService Modal { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public ISurveyManager SurveyManager { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<SurveyDTO> SurveyList { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        private bool isReady = false;

        protected override async Task OnInitializedAsync()
        {
            var result = await SurveyManager.GetAllSurveysAsync();

            if (result.IsSuccess)
            {
                SurveyList = result.Value;
            }

            isReady = true;
        }

        private void EditSurvey(int id)
        {
            NavigationManager.NavigateTo($"survey/edit/{id}");
        }

        private async Task DeleteSurvey(int id)
        {
            ModalParameters parameters = new ModalParameters();
            parameters.Add("Message", "Silmek istediğinize emin misiniz?");
            var formModal = Modal.Show<Confirm>("Anketi Sil", parameters);

            var result = await formModal.Result;

            if (!result.Cancelled)
            {


                var deleteResult = await SurveyManager.DeleteSurveyAsync(id);

                if (deleteResult.IsSuccess)
                {

                    var newSurveyList = await SurveyManager.GetAllSurveysAsync();

                    if (newSurveyList.IsSuccess)
                    {
                        SurveyList = newSurveyList.Value;
                        ToastService.ShowSuccess("", "Anket silindi!");
                    }
                    else
                    {
                        ToastService.ShowError("", "Anket silme esnasında bir hata meydana geldi!");
                    }

                }
            }


            NavigationManager.NavigateTo($"surveylist/edit");
        }

    }
}
