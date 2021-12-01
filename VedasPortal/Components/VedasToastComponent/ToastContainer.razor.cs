using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using VedasPortal.Components.VedasToastComponent.Core;

namespace VedasPortal.Components.VedasToastComponent
{
    public class ToastContainerModel : ComponentBase, IDisposable
    {
        [Inject] private IVedasToaster Toaster { get; set; }

        protected IEnumerable<VedasToast> Toasts => Toaster.Configuration.NewestOnTop
                ? Toaster.ShownToasts.Reverse()
                : Toaster.ShownToasts;

        protected string Class => Toaster.Configuration.PositionClass;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Toaster.OnToastsUpdated += () => InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            Toaster.OnToastsUpdated -= StateHasChanged;
        }
    }
}