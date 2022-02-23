using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.ViewModels;

namespace VedasPortal.Components.Anket.Modals
{
    public partial class AnketSecenekEkle : ComponentBase
    {

        [CascadingParameter]
        BlazoredModalInstance Modal { get; set; }

        [Parameter]
        public int AnketId { get; set; }

        [Inject]
        private VedasDbContext Context { get; set; }

        [Inject]
        public IAnketYonetim SurveyManager { get; set; }

        private EditContext editContext { get; set; }

        private AnketSecenekVm optionModel { get; set; } = new AnketSecenekVm();
        private AnketSecenekDTO model = new AnketSecenekDTO();

        protected override void OnInitialized()
        {

            editContext = new EditContext(optionModel);
            optionModel.Fk_AnketId = AnketId;
        }

        private async Task SaveOption()
        {
            model.Fk_AnketId = optionModel.Fk_AnketId;
            model.Aciklama = optionModel.Aciklama;
            model.Resim = optionModel.Resim;
            model.ToplamKatilim = 0;

            await Modal.CloseAsync(ModalResult.Ok(model));
        }

        void Cancel() => Modal.CancelAsync();

        public ShowModalComponent ModalShow { get; set; }

    }
}
