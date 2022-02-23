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

        private AnketSecenekVm optionModel { get; set; } = new AnketSecenekVm();
        private AnketSecenekDTO model = new AnketSecenekDTO();

        protected override void OnInitialized()
        {
            editContext = new EditContext(optionModel);
        }

        private Task SaveOption()
        {

            model.Aciklama = optionModel.Aciklama;
            model.Resim = optionModel.Resim;
            model.ToplamKatilim = 0;

            return Modal.CloseAsync(ModalResult.Ok(model));
        }

        void Cancel() => Modal.CancelAsync();

        public ShowModalComponent ModalShow { get; set; }


    }
}
