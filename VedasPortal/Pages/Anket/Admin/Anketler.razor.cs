using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.Anket.Modals;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;

namespace VedasPortal.Pages.Anket.Admin
{
    public partial class Anketler : ComponentBase
    {

        [Inject]
        public VedasDbContext Context { get; set; }

        [CascadingParameter]
        IModalService Modal { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public List<AnketDTO> AnketListe { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

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

        private void Duzenle(int id)
        {
            NavigationManager.NavigateTo($"anket/duzenle/{id}");
        }

        private async Task Sil(int id)
        {
            ModalParameters parameters = new();
            parameters.Add("Message", "Silmek istediğinize emin misiniz?");
            var formModal = Modal.Show<OnayComponent>("Anketi Sil", parameters);

            var result = await formModal.Result;

            if (!result.Cancelled)
            {


                var deleteResult = await AnketYonetim.AnketSilAsync(id);

                if (deleteResult.IsSuccess)
                {

                    var yeniAnketListe = await AnketYonetim.TumAnketleriGetirAsync();

                    if (yeniAnketListe.IsSuccess)
                    {
                        AnketListe = yeniAnketListe.Value;
                        ToastService.ShowSuccess("", "Anket silindi!");
                    }
                    else
                    {
                        ToastService.ShowError("", "Anket silme esnasında bir hata meydana geldi!");
                    }

                }
            }


            NavigationManager.NavigateTo($"anketlerlistesi");
        }

    }
}
