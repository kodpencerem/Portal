using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Components.Anket.Modals;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.ViewModels;
using VedasPortal.Utils.Anket;
using Confirm = VedasPortal.Components.Anket.Modals.Confirm;

namespace VedasPortal.Components.Anket
{
    public partial class EditSurvey : ComponentBase
    {


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public VedasDbContext Context { get; set; }

        [Inject]
        public Mapper mapper { get; set; }

        [CascadingParameter]
        IModalService Modal { get; set; }

        [Inject]
        public ISurveyManager SurveyManager { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [CascadingParameter]
        public int Id { get; set; }

        private bool isReady = false;

        private SurveyDTO Survey;

        private EditSurveyViewModel SurveyToUpdate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await SurveyManager.GetSurveyAsync(Id);

            if (result.IsSuccess)
            {
                Survey = result.Value;
                SurveyToUpdate = mapper.SurveyToEditSurveyModel(Survey);
            }


            isReady = true;
        }


        private async Task UpdateSurvey()
        {
            var updatedSurvey = SurveyToUpdate;

            Survey.SurveyName = SurveyToUpdate.SurveyName;
            Survey.SurveyQuestion = SurveyToUpdate.SurveyQuestion;
            Survey.FeaturedSurvey = SurveyToUpdate.FeaturedSurvey;
            Survey.Description = SurveyToUpdate.Description;
            Survey.SurveyOptions = SurveyToUpdate.SurveyOptionsToAdd;

            var result = await SurveyManager.UpdateSurveyAsync(Survey);

            if (result.IsSuccess)
            {
                ToastService.ShowSuccess("", "Anket Güncellendi");
                NavigationManager.NavigateTo("surveylist/edit");
            }
            else
            {
                ToastService.ShowError("Güncelleme sırasında bir hata meydana geldi", "Hata");
            }

        }

        private void CancelUpdate()
        {
            NavigationManager.NavigateTo("surveylist/edit");
        }

        private async Task DeleteOption(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add("SurveyOptionId", id);
            parameters.Add("Message", "Silmek istediğinize emin misiniz?");
            var formModal = Modal.Show<Confirm>("Silme İşlemi", parameters);
            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                SurveyToUpdate.RemoveSurveyOption(id);
            }
        }

        private async Task AddOption()
        {
            var parameters = new ModalParameters();
            parameters.Add("SurveyId", SurveyToUpdate.SurveyId);

            var formModal = Modal.Show<AddOption>("Seçenek Ekle", parameters);

            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                var results = result.Data;
                SurveyToUpdate.AddSurveyOption((SurveyOptionDTO)result.Data);
            }
        }


    }
}
