using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Pages.Anket
{
    public partial class Anketler : ComponentBase
    {

        [Inject]
        public VedasDbContext Context { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<AnketDTO> AnketListe { get; set; }

        private bool isReady = false;

        protected override async Task OnInitializedAsync()
        {
            var result = await AnketYonetim.TumAnketleriGetirAsync();

            if (result.IsSuccess)
            {
                AnketListe = result.Value;
            }

            isReady = true;
        }

        private void AnketiGetir(int id)
        {
            NavigationManager.NavigateTo($"anket/{id}");
        }

        private void SonuclariGoster(int id)
        {
            NavigationManager.NavigateTo($"anket/sonuc/{id}");
        }

    }
}
