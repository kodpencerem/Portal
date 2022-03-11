using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using VedasPortal.Entities.DTOs.Anket;
using VedasPortal.Entities.ViewModels.Anket;

namespace VedasPortal.Components.Anket.Modals
{
    public partial class YeniAnketSecenekEkle : ComponentBase
    {
        [CascadingParameter]
        BlazoredModalInstance Modal { get; set; }
       
        private EditContext editContext { get; set; }

        private AnketSecenekVm AnketSecenekVm { get; set; } = new AnketSecenekVm();
        private AnketSecenekDTO AnketSecenekDTO = new AnketSecenekDTO();

        protected override void OnInitialized()
        {
            editContext = new EditContext(AnketSecenekVm);
        }
        private Task SecenekKayit()
        {

            AnketSecenekDTO.Aciklama = AnketSecenekVm.Aciklama;
            AnketSecenekDTO.Resim = AnketSecenekVm.Resim;
            AnketSecenekDTO.ToplamKatilim = 0;

            return Modal.CloseAsync(ModalResult.Ok(AnketSecenekDTO));
        }

        void Cancel() => Modal.CancelAsync();     
        
    }
}
