// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace VedasPortal.Components.Anket.Modals
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
    public partial class YeniAnketSecenekEkle : global::Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JSRuntime { get; set; }
    }
}
#pragma warning restore 1591