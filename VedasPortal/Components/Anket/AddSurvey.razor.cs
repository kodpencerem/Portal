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

namespace VedasPortal.Components.Anket
{
    public partial class AddSurvey : ComponentBase
    {


        private bool isReady = true;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public VedasDbContext Context { get; set; }

        [Inject]
        public ISurveyManager SurveyManager { get; set; }

        [Inject]
        public Mapper mapper { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [CascadingParameter]
        IModalService Modal { get; set; }

        private AddSurveyViewModel model = new AddSurveyViewModel();

        private async Task SaveSurvey()
        {
            var result = await SurveyManager.AddSurveyAsync(model.GenerateSurveyToSave());

            if (result.IsSuccess)
            {
                ToastService.ShowSuccess("Anket başarıyla eklendi..", "İşlem Başarılı");
                NavigationManager.NavigateTo("surveylist/edit");
            }
            else
            {
                ToastService.ShowError("Ekleme esnasında bir hata ile karşılaşıdı!", "Hata!");
            }


        }

        private void CancelAdd()
        {
            NavigationManager.NavigateTo("/");
        }



        private async Task DeleteOption(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add("SurveyOptionId", id);
            parameters.Add("Message", "Silmek istediğinize emin misiniz??");
            var formModal = Modal.Show<Confirm>("Silme İşlemi", parameters);
            var result = await formModal.Result;

            if (!result.Cancelled)
            {

                model.RemoveSurveyOption(id);
                ToastService.ShowSuccess("", "Silindi");
            }
        }

        private async Task AddOption()
        {
            var maxId = model.GetMaxId();
            var formModal = Modal.Show<NewSurveyOption>("Bir seçenek ekleyin");

            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                var results = result.Data;
                model.AddSurveyOption((SurveyOptionDTO)result.Data, maxId);
                model.SurveyOptionsToAdd.Add((SurveyOptionDTO)result.Data);

            }
        }

    }

}

