#pragma checksum "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "13359f71fc03dcef54ccbb436ef79634f96c8099"
// <auto-generated/>
#pragma warning disable 1591
namespace VedasPortal.Pages.PersonelBilgilendirme.Personel
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
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/Doganlar")]
    public partial class Doganlar : DogumGunuModeli
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 4 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
 if (DogumGunleri == null)

{

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "<p><em>Yükleniyor...</em></p>");
#nullable restore
#line 7 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
                                  }

else

{


#line default
#line hidden
#nullable disable
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "col-12");
            __builder.OpenComponent<global::VedasPortal.Components.IndexComponents.CardComponent>(3);
            __builder.AddAttribute(4, "cardStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::VedasPortal.Enums.Style>(
#nullable restore
#line 14 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
                                  Style.info

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "CardHeader", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(6, "\r\n                Bu Hafta Doğanlar\r\n            ");
            }
            ));
            __builder.AddAttribute(7, "CardBody", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "row");
#nullable restore
#line 20 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
                     foreach (var dogumGunu in DogumGunleri.Where(
                         a => a.DogumTarihi.Date.ToShortDateString()==DateTime.Now.Date.ToShortDateString() && 
                         a.AktifPasif == true))
                    {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "style", "margin-top:-15px");
                __builder2.AddAttribute(12, "class", "col-lg-4 col-sm-12 col-md-6 col-xs-12");
                __builder2.OpenComponent<global::VedasPortal.Components.IndexComponents.CardComponent>(13);
                __builder2.AddAttribute(14, "cardStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::VedasPortal.Enums.Style>(
#nullable restore
#line 25 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
                                                      Style.info

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(15, "CardBody", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(16, "div");
                    __builder3.AddAttribute(17, "class", "author-box-center align-center");
                    __builder3.OpenElement(18, "img");
                    __builder3.AddAttribute(19, "width", "200");
                    __builder3.AddAttribute(20, "height", "200");
                    __builder3.AddAttribute(21, "alt", "image");
                    __builder3.AddAttribute(22, "src", "images/uploaded/" + (
#nullable restore
#line 31 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
                                                                   string.Concat(
                                                                       dogumGunu.ImageFile.FirstOrDefault().Adi,
                                                                       ".",
                                                                       dogumGunu.ImageFile.FirstOrDefault().Uzanti)

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(23, "class", "rounded-circle author-box-picture");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(24, "\r\n                                        <div class=\"clearfix\"></div>");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(25, "\r\n                                    ");
                    __builder3.OpenElement(26, "div");
                    __builder3.AddAttribute(27, "class", "author-box-details ");
                    __builder3.OpenElement(28, "div");
                    __builder3.AddAttribute(29, "class", "author-box-name text-center");
                    __builder3.OpenElement(30, "a");
#nullable restore
#line 40 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
__builder3.AddContent(31, dogumGunu.AdSoyad);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(32, "\r\n                                        ");
                    __builder3.OpenElement(33, "div");
                    __builder3.AddAttribute(34, "class", "author-box-job text-center");
#nullable restore
#line 42 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
__builder3.AddContent(35, dogumGunu.BasladigiGorev);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(36, "\r\n                                        ");
                    __builder3.AddMarkupContent(37, @"<div class=""author-box-description""><p><h5 style=""color:darkblue"" class=""text-center"">
                                                    İyiki Doğdunuz...
                                                </h5>
                                                <h6 style=""color:blue"" class=""text-center"">
                                                    Vedaş Ailesi Olarak Doğum Gününüzü Tebrik Eder. Nice Güzel Seneler Dileriz.
                                                </h6></p></div>
                                        ");
                    __builder3.AddMarkupContent(38, "<div class=\"mb-2 mt-3 text-center\"><button class=\"btn btn-success\" type=\"submit\">Tebrik Et</button></div>\r\n                                        ");
                    __builder3.AddMarkupContent(39, "<div class=\"float-right mt-sm-0 mt-3\"><a href=\"Profil\" class=\"btn\">Personel Detay Bilgileri<i class=\"fas fa-chevron-right\"></i></a></div>");
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.CloseElement();
#nullable restore
#line 65 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"

                    }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 71 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\PersonelBilgilendirme\Personel\Doganlar.razor"
          }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(40, @"<style>
    .article .article-details {
        min-height: 220px;
        max-height: 290px;
    }

    .theme-white .btn-primary {
        margin-left: 8rem;
        background-color: #6777ef;
        border-color: transparent !important;
        color: #fff;
    }
</style>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591