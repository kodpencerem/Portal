#pragma checksum "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e954cb8db12dc0fcc59cbda9f50b99758406ee42"
// <auto-generated/>
#pragma warning disable 1591
namespace VedasPortal.Pages.ToplantiOdalari
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
    [global::Microsoft.AspNetCore.Components.RouteAttribute("/odadetayformu/{odaId:int}")]
    public partial class OdaDetay : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "col-12");
            __builder.AddAttribute(2, "b-4klltzs56o");
            __builder.OpenComponent<global::VedasPortal.Components.IndexComponents.CardComponent>(3);
            __builder.AddAttribute(4, "cardStyle", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<global::VedasPortal.Enums.Style>(
#nullable restore
#line 4 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                              Style.primary

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "CardHeader", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(6, "<div class=\"float-left\" b-4klltzs56o><div class=\"col-md-12\" b-4klltzs56o>\r\n                    Toplantı Odası Detay Formu\r\n                </div></div>");
            }
            ));
            __builder.AddAttribute(7, "CardBody", (global::Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
#nullable restore
#line 13 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
              if (OdaDetayGetir != null)
                {

#line default
#line hidden
#nullable disable
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "padding-5");
                __builder2.AddAttribute(10, "b-4klltzs56o");
                __builder2.OpenElement(11, "div");
                __builder2.AddAttribute(12, "class", "tab-content tab-bordered");
                __builder2.AddAttribute(13, "id", "myTab3Content");
                __builder2.AddAttribute(14, "b-4klltzs56o");
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "tab-pane fade active show");
                __builder2.AddAttribute(17, "id", "about");
                __builder2.AddAttribute(18, "role", "tabpanel");
                __builder2.AddAttribute(19, "aria-labelledby", "home-tab2");
                __builder2.AddAttribute(20, "b-4klltzs56o");
                __builder2.OpenElement(21, "p");
                __builder2.AddAttribute(22, "class", "m-t-30");
                __builder2.AddAttribute(23, "b-4klltzs56o");
                __builder2.AddMarkupContent(24, "<strong b-4klltzs56o>\r\n                                        Toplantı Odası Adı:\r\n                                    </strong>\r\n                                    ");
#nullable restore
#line 28 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
__builder2.AddContent(25, OdaDetayGetir.Adi);

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(26, "  <br b-4klltzs56o><br b-4klltzs56o>\r\n                                    ");
                __builder2.AddMarkupContent(27, "<strong b-4klltzs56o>\r\n                                        Bulunduğu Lokasyon:\r\n                                    </strong>\r\n                                    ");
#nullable restore
#line 32 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
__builder2.AddContent(28, OdaDetayGetir.Adres);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(29, "\r\n                                ");
                __builder2.OpenElement(30, "p");
                __builder2.AddAttribute(31, "b-4klltzs56o");
                __builder2.AddMarkupContent(32, "<strong b-4klltzs56o>\r\n                                        Açıklama: \r\n                                    </strong>\r\n                                    ");
#nullable restore
#line 38 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
__builder2.AddContent(33, (MarkupString) OdaDetayGetir.Aciklama);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(34, "\r\n                                ");
                __builder2.OpenElement(35, "p");
                __builder2.AddAttribute(36, "b-4klltzs56o");
                __builder2.AddMarkupContent(37, "<strong b-4klltzs56o>\r\n                                        Oda Kapasite:\r\n                                    </strong>\r\n                                    ");
#nullable restore
#line 44 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
__builder2.AddContent(38, OdaDetayGetir.Kapasite);

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.AddMarkupContent(39, "\r\n\r\n                                ");
                __builder2.AddMarkupContent(40, "<div class=\"section-title\" b-4klltzs56o><strong b-4klltzs56o>\r\n                                        Video Konferans Destekliyor Mu?:\r\n                                    </strong></div>");
#nullable restore
#line 53 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                                 if (@OdaDetayGetir.VideoKonferansMi == true)
                                {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(41, "<p class=\"text-primary\" b-4klltzs56o><strong b-4klltzs56o>\r\n                                            Evet Destekliyor.\r\n                                        </strong></p>");
#nullable restore
#line 60 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(42, "<p class=\"text-danger\" b-4klltzs56o><strong b-4klltzs56o>\r\n                                            Hayır. Desteklemiyor\r\n                                        </strong></p>");
#nullable restore
#line 68 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                                }

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(43, "<div class=\"section-title\" b-4klltzs56o><strong b-4klltzs56o>\r\n                                        Rezerv Durumu:\r\n                                    </strong></div>\r\n                                ");
                __builder2.OpenElement(44, "ul");
                __builder2.AddAttribute(45, "b-4klltzs56o");
#nullable restore
#line 76 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                                     if (OdaDetayGetir.RezervDurumu == true)
                                    {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(46, "<li class=\"text-danger\" b-4klltzs56o>Evet Rezerv Edilmiştir.</li>");
#nullable restore
#line 79 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                                    }
                                    else
                                    {

#line default
#line hidden
#nullable disable
                __builder2.AddMarkupContent(47, "<li class=\"text-success\" b-4klltzs56o>Rezerv Edilmemiştir.Rezerv Edilebilir</li>");
#nullable restore
#line 83 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                                    }

#line default
#line hidden
#nullable disable
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
#nullable restore
#line 87 "C:\Users\t1emrullahisik\source\repos\Vedas_Portal\VedasPortal\Pages\ToplantiOdalari\OdaDetay.razor"
                           } 

#line default
#line hidden
#nullable disable
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(48, "\r\n\r\n");
            __builder.AddMarkupContent(49, @"<style b-4klltzs56o>
    .row {
        display: -ms-flexbox;
        display: -webkit-box;
        display: flex;
        -ms-flex-wrap: wrap;
        flex-wrap: wrap;
        margin-top: -15px;
        margin-right: -15px;
        margin-left: -15px;
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