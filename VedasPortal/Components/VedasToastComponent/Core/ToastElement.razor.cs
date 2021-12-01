using System;
using Microsoft.AspNetCore.Components;

namespace VedasPortal.Components.VedasToastComponent.Core
{
    public class ToastElementModel : ComponentBase, IDisposable
    {
        [Parameter]
        public VedasToast Toast { get; set; }
        protected RenderFragment Css;

        protected string Title => Toast.Title;
        protected string Message => Toast.Message;

        protected void Clicked() => Toast.Clicked(false);
        protected void CloseIconClicked() => Toast.Clicked(true);
        protected void MouseEnter() => Toast.MouseEnter();
        protected void MouseLeave() => Toast.MouseLeave();

        protected override void OnInitialized()
        {
            Toast.OnUpdate += ToastUpdated;
            Toast.Init();

            Css = builder =>
            {
                var transitionClass = Toast.State.TransitionClass;
                if (transitionClass.IsEmpty()) return;

                builder.OpenElement(1, "style");
                builder.AddContent(2, transitionClass);
                builder.CloseElement();
            };
        }

        private void ToastUpdated()
        {
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || Toast == null) return;
            Toast.OnUpdate -= ToastUpdated;
        }
    }
}