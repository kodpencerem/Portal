using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.ViewModels;

namespace VedasPortal.Components.Anket.Modals
{
    public partial class AddOption : ComponentBase
    {

        [CascadingParameter]
        BlazoredModalInstance Modal { get; set; }

        [Parameter]
        public int SurveyId { get; set; }

        [Inject]
        private VedasDbContext Context { get; set; }

        [Inject]
        public ISurveyManager SurveyManager { get; set; }

        private EditContext editContext { get; set; }

        private OptionViewModel optionModel { get; set; } = new OptionViewModel();
        private SurveyOptionDTO model = new SurveyOptionDTO();

        protected override void OnInitialized()
        {

            editContext = new EditContext(optionModel);
            optionModel.Fk_SurveyId = SurveyId;
        }

        private async Task SaveOption()
        {
            model.Fk_SurveyId = optionModel.Fk_SurveyId;
            model.Description = optionModel.Description;
            model.ImagePath = optionModel.ImagePath;
            model.TotalVotes = 0;

            await Modal.CloseAsync(ModalResult.Ok(model));
        }

        void Cancel() => Modal.CancelAsync();

    }
}
