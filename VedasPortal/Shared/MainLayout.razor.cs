using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace VedasPortal.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IJSRuntime jsRun { get; set; }


        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            await jsRun.InvokeVoidAsync("scriptsInit");
            if (firstRender)
            {
                await jsRun.InvokeVoidAsync("indexInit");
                
                
            }
            
            


        }
    }
}
