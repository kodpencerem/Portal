using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace VedasPortal.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IJSRuntime JsRun { get; set; }


        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            await JsRun.InvokeVoidAsync("scriptsInit");
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("indexInit");
            }
        }
    }
}