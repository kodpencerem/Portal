using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.ViewModels;

namespace VedasPortal.Components.Anket.Modals
{
    public partial class YeniAnketSecenekEkle : ComponentBase
    {
        [CascadingParameter]
        BlazoredModalInstance Modal { get; set; }
       
        private EditContext editContext { get; set; }

        private OptionViewModel optionModel { get; set; } = new OptionViewModel();
        private SurveyOptionDTO model = new SurveyOptionDTO();

        protected override void OnInitialized()
        {
            editContext = new EditContext(optionModel);
        }

        private Task SaveOption()
        {

            model.Description = optionModel.Description;
            model.ImagePath = optionModel.ImagePath;
            model.TotalVotes = 0;

            return Modal.CloseAsync(ModalResult.Ok(model));
        }

        void Cancel() => Modal.CancelAsync();

        public ShowModalComponent ModalShow { get; set; }


    }
}
