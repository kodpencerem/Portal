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
            await jsRun.InvokeVoidAsync("indexInit");
            await jsRun.InvokeVoidAsync("scriptsInit");
            await jsRun.InvokeVoidAsync("sweetAlert");
            await jsRun.InvokeVoidAsync("toastrVedas");
            

            if (firstRender)
            {

                await jsRun.InvokeVoidAsync("owlCarousel");
                await jsRun.InvokeVoidAsync("lightGallery");
                await jsRun.InvokeVoidAsync("formWizard");
                await jsRun.InvokeVoidAsync("calendar");
               
               

                
            }
            else
            {
                await jsRun.InvokeVoidAsync("multipleUpload");
            }

        }
    }
}
