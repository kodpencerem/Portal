using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Entities.Models.Yorum;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.OneriSistemi
{
    public partial class OneriDetay
    {
        [Inject]
        private IBaseRepository<Oneri> Oneri { get; set; }

        [Parameter]
        public int OneriId { get; set; }
        public ImageFile OneriDetayDosya { get; set; }
        private Oneri OneriDetayGetir { get; set; } = new();

        [Inject]
        public IBaseRepository<Yorum> GelenYorumlar { get; set; }

        [Parameter]
        public int YorumId { get; set; }

        protected string Title = "Ekle";
        public Yorum yorum = new();

        protected override Task OnInitializedAsync()
        {
            OneriDetayGetir = Oneri.Get(OneriId);
            TumYorumlariGetir();
            return Task.CompletedTask;
        }
        
        protected IEnumerable<Yorum> YorumListesi { get; set; }

        protected IEnumerable<Yorum> TumYorumlariGetir()
        {
            YorumListesi = GelenYorumlar.GetAll();

            return YorumListesi;

        }       
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void SilmeyiOnayla(int YorumId)
        {
            ModalDialog.Open();
            yorum = YorumListesi.FirstOrDefault(x => x.Id == YorumId);
        }

        protected void Sil()
        {
            if (yorum.Id == 0)
                return;

            GelenYorumlar.Remove(yorum.Id);
            yorum = new Yorum();
            TumYorumlariGetir();
        }
        protected void Kayit()
        {
            var yorumEkle = new Yorum()
            {   Aciklama = yorum.Aciklama,            
                OneriId = OneriDetayGetir.Id
            };
            GelenYorumlar.Add(yorumEkle);
            yorum = new Yorum();

        }

        protected override void OnParametersSet()
        {
            if (YorumId != 0)
            {
                Title = "Duzenle";
                yorum = GelenYorumlar.Get(YorumId);
            }
        }


        [Inject]
        public IJSRuntime JsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("dataTables");
                await JsRun.InvokeVoidAsync("lightGallery");
            }
        }
    }
}
