using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;

namespace VedasPortal.Components.Anket.Modals
{
    public partial class OnayComponent : ComponentBase
    {

        [CascadingParameter]
        BlazoredModalInstance Modal { get; set; }

        [Parameter]
        public int SurveyOptionId { get; set; }

        [Parameter]
        public string Message { get; set; }

        void Accept() => Modal.CloseAsync(ModalResult.Ok(SurveyOptionId));
        void Cancel() => Modal.CancelAsync();


    }
}
