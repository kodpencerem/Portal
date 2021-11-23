using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace VedasPortal.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public IJSRuntime jsRun { get; set; }
        private string message = "/index";


        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
               
                await jsRun.InvokeVoidAsync("owlCarousel");
                await jsRun.InvokeVoidAsync("jssor_1_slider_init");
               

            }
			else
			{
                await jsRun.InvokeVoidAsync("lightGallery");
                await jsRun.InvokeVoidAsync("sweetAlert");
                await jsRun.InvokeVoidAsync("ckEditor");
                
                
            }

            await jsRun.InvokeVoidAsync("indexInit");
            await jsRun.InvokeVoidAsync("scriptsInit");
        }
    }
}
