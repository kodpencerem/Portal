#pragma checksum "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Components\IndexComponents\SliderComponent.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2cdc59d0025a5c3cee3cd99dea7c840ab98ce2e9"
// <auto-generated/>
#pragma warning disable 1591
namespace VedasPortal.Components.IndexComponents
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.IndexComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.UploadComponent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.Alert;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Entities.Models.Base;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Entities.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.ShowModalComponent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.Alert.SweetAlert;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.VideoComponent;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.ToplantiTakvimi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Entities.Models.DovizKurlari;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Services.Doviz;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.ErrorPages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Entities.Models.Dosya;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using System.IO;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.Extensions.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Entities.Models.HaberDuyuru;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazor.Cropper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Entities.Models.Etkinlik;

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Utils.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.Anket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.Anket.Modals;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.Toast.Configuration;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Entities.Models.Anket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.Kanban;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Services.Anket;

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.Video;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.Video.Support;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazorise.Sidebar;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazorise.DataGrid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 51 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using BlazorTable;

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using VedasPortal.Components.Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 55 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Syncfusion.Blazor.Navigations;

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\_Imports.razor"
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
    public partial class SliderComponent : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<global::VedasPortal.Components.IndexComponents.CardComponent>(0);
            __builder.AddAttribute(1, "CardHeader", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(2, "\r\n\t\tSlider Duyuru Kutusu\r\n\t");
            }
            ));
            __builder.AddAttribute(3, "CardBody", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(4, "<div id=\"carouselExampleIndicators2\" class=\"carousel slide\" data-ride=\"carousel\" style=\"box-shadow:0px 0px 3px #808080\"><ol class=\"carousel-indicators\"><li data-target=\"#carouselExampleIndicators2\" data-slide-to=\"0\" class=\"active\"></li>\r\n\t\t\t\t<li data-target=\"#carouselExampleIndicators2\" data-slide-to=\"1\"></li></ol>\r\n\t\t\t<div class=\"carousel-inner\" style=\"outline:1px #808080\"><div class=\"carousel-item active\"><img class=\"d-block w-100\" src=\"https://www.vedas.com.tr/cropped/?src=dosyalar/page_7/img_11601884546.jpg&w=1200\" alt=\"First slide\">\r\n\t\t\t\t\t<div class=\"carousel-caption d-none d-md-block\"><h5 class=\"text-dark\">??evre Ayd??nlatma</h5>\r\n\t\t\t\t\t\t<h3 style=\"-webkit-text-stroke: 0.3px black;\">\r\n\t\t\t\t\t\t\tHedefimiz daima en iyisi\r\n\t\t\t\t\t\t</h3></div></div>\r\n\t\t\t\t<div class=\"carousel-item\"><img class=\"d-block w-100\" src=\"https://www.vedas.com.tr/cropped/?src=dosyalar/page_8/img_11601884594.jpg&w=1200\" alt=\"Second slide\">\r\n\t\t\t\t\t<div class=\"carousel-caption d-none d-md-block\"><h5 class=\"text-dark\">K??pr?? ve ??st Ge??it I????klar??</h5>\r\n\t\t\t\t\t\t<h3 style=\"-webkit-text-stroke: 0.5px black;\">\r\n\t\t\t\t\t\t\tBu enerji hepmizin\r\n\t\t\t\t\t\t</h3></div></div></div>\r\n\t\t\t<a class=\"carousel-control-prev\" href=\"#carouselExampleIndicators2\" role=\"button\" data-slide=\"prev\"><span class=\"carousel-control-prev-icon\" aria-hidden=\"true\"></span>\r\n\t\t\t\t<span class=\"sr-only\">??nceki</span></a>\r\n\t\t\t<a class=\"carousel-control-next\" href=\"#carouselExampleIndicators2\" role=\"button\" data-slide=\"next\"><span class=\"carousel-control-next-icon\" aria-hidden=\"true\"></span>\r\n\t\t\t\t<span class=\"sr-only\">Sonraki</span></a></div>");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591
