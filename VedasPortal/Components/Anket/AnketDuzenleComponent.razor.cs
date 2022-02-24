using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;
using VedasPortal.Components.Anket.Modals;
using VedasPortal.Data;
using VedasPortal.Models.Anket.Contracts;
using VedasPortal.Models.Anket.DTO;
using VedasPortal.Models.Anket.ViewModels;
using VedasPortal.Utils.Anket;
using Confirm = VedasPortal.Components.Anket.Modals.OnayComponent;

namespace VedasPortal.Components.Anket
{
    public partial class AnketDuzenleComponent : ComponentBase
    {


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        [Inject]
        public VedasDbContext Context { get; set; }

        [Inject]
        public Mapper mapper { get; set; }

        [CascadingParameter]
        IModalService Modal { get; set; }

        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [CascadingParameter]
        public int Id { get; set; }

        private bool isReady = false;

        private AnketDTO AnketDTO;

        private AnketDuzenleVm AnketGuncelle { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await AnketYonetim.AnketGetirAsync(Id);

            if (result.IsSuccess)
            {
                AnketDTO = result.Value;
                AnketGuncelle = mapper.AnketToAnketDuzenlemeModeli(AnketDTO);
            }


            isReady = true;
        }


        private async Task AnketiDuzenle()
        {
            var updatedSurvey = AnketGuncelle;

            AnketDTO.Adi = AnketGuncelle.Adi;
            AnketDTO.AnketSorusu = AnketGuncelle.AnketSorusu;
            AnketDTO.SecilenAnketMi = AnketGuncelle.SecilenAnketMi;
            AnketDTO.Aciklama = AnketGuncelle.Aciklama;
            AnketDTO.AnketSecenekleri = AnketGuncelle.AnketSecenekEkle;

            var result = await AnketYonetim.AnketDuzenleAsync(AnketDTO);

            if (result.IsSuccess)
            {
                ToastService.ShowSuccess("", "Anket Güncellendi");
                NavigationManager.NavigateTo("anketlerlistesi");
            }
            else
            {
                ToastService.ShowError("Güncelleme sırasında bir hata meydana geldi", "Hata");
            }

        }

        private void CancelUpdate()
        {
            NavigationManager.NavigateTo("anketlerlistesi");
        }

        private async Task SecenekSil(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add("AnketSecenekId", id);
            parameters.Add("Message", "Silmek istediğinize emin misiniz?");
            var formModal = Modal.Show<Confirm>("Silme İşlemi", parameters);
            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                AnketGuncelle.AnketSecenekSil(id);
            }
        }

        private async Task SecenekEkle()
        {
            var parameters = new ModalParameters();
            parameters.Add("AnketId", AnketGuncelle.AnketId);

            var formModal = Modal.Show<AnketSecenekEkle>("Seçenek Ekle", parameters);

            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                var results = result.Data;
                AnketGuncelle.AnketSecenekleriEkle((AnketSecenekDTO)result.Data);
            }
        }


    }
}
