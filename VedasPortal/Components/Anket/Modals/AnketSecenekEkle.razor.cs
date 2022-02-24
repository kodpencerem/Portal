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

        //[Inject]
        //private VedasDbContext Context { get; set; }

        //[Inject]
        //public IAnketYonetim AnketYonetim { get; set; }

        private EditContext editContext { get; set; }

        private AnketSecenekVm AnketSecenekVm { get; set; } = new AnketSecenekVm();
        private AnketSecenekDTO AnketSecenekDTO = new();

        protected override void OnInitialized()
        {

            editContext = new EditContext(AnketSecenekVm);
            AnketSecenekVm.Fk_AnketId = AnketId;
        }

        private async Task SecenekKayit()
        {
            AnketSecenekDTO.Fk_AnketId = AnketSecenekVm.Fk_AnketId;
            AnketSecenekDTO.Aciklama = AnketSecenekVm.Aciklama;
            AnketSecenekDTO.Resim = AnketSecenekVm.Resim;
            AnketSecenekDTO.ToplamKatilim = 0;

            await Modal.CloseAsync(ModalResult.Ok(AnketSecenekDTO));
        }

        void Cancel() => Modal.CancelAsync();

        public ShowModalComponent ModalShow { get; set; }

    }
}
