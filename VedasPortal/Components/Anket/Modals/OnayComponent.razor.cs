using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using VedasPortal.Components.ShowModalComponent;

namespace VedasPortal.Components.Anket.Modals
{
    public partial class OnayComponent : ComponentBase
    {

        [CascadingParameter]
        BlazoredModalInstance Modal { get; set; }

        [Parameter]
        public int AnketSecenekId { get; set; }

        [Parameter]
        public string Message { get; set; }

        void Accept() => Modal.CloseAsync(ModalResult.Ok(AnketSecenekId));
        void Cancel() => Modal.CancelAsync();
        public ShowModal ModalShow { get; set; }
    }
}
