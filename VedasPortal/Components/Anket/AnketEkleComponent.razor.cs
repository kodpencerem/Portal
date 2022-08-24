using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Components.Anket.Modals;
using VedasPortal.Data;
using VedasPortal.Entities.DTOs.Anket;
using VedasPortal.Entities.ViewModels.Anket;
using VedasPortal.Repository.Interface.Anket;
using VedasPortal.Utils.Anket.FromMapper;

namespace VedasPortal.Components.Anket
{
    public partial class AnketEkleComponent : ComponentBase
    {


        private bool isReady = true;

        [Inject]
        public VedasDbContext Context { get; set; }

        [Inject]
        public IAnketYonetim AnketYonetim { get; set; }

        [Inject]
        public Mapper mapper { get; set; }

        [Inject]
        public IToastService ToastService { get; set; }

        [CascadingParameter]
        IModalService Modal { get; set; }

        private AnketEkleVm AnketEkle = new();

        private async Task AnketKayit()
        {
            var result = await AnketYonetim.AnketEkleAsync(AnketEkle.AnketOlustur());

            if (result.IsSuccess)
            {
                ToastService.ShowSuccess("Anket başarıyla eklendi..", "İşlem Başarılı");
                NavigationManager.NavigateTo("anketlerlistesi");
            }
            else
            {
                ToastService.ShowError("Ekleme esnasında bir hata ile karşılaşıdı!", "Hata!");
            }


        }

        private void Vazgec()
        {
            NavigationManager.NavigateTo("/");
        }



        private async Task SecenekSil(int id)
        {
            var parameters = new ModalParameters();
            parameters.Add("AnketSecenekId", id);
            parameters.Add("Message", "Silmek istediğinize emin misiniz??");
            var formModal = Modal.Show<OnayComponent>("Silme İşlemi", parameters);
            var result = await formModal.Result;

            if (!result.Cancelled)
            {

                AnketEkle.AnketSecenekSil(id);
                ToastService.ShowSuccess("", "Silindi");
            }
        }


        private async Task SecenekEkle()
        {
            var maxId = AnketEkle.MaxIdGetir();
            var formModal = Modal.Show<YeniAnketSecenekEkle>("Bir seçenek ekleyin");

            var result = await formModal.Result;

            if (!result.Cancelled)
            {
                var results = result?.Data;
                AnketEkle.AnketSorusuEkle((AnketSecenekDTO)result.Data, maxId);
                AnketEkle.AnketSecenekEkle.Add((AnketSecenekDTO)result.Data);

            }
        }

    }

}

