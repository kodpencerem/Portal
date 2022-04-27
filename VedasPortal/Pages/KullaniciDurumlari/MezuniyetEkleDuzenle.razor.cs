using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Kullanici
{
    public class MezunBilgiModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<OkulMezunBilgisi> MezunBilgisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int MezunId { get; set; }

        protected string Title = "Ekle";
        public OkulMezunBilgisi okulMezunBilgisi = new();

        protected IEnumerable<OkulMezunBilgisi> MezunBilgileri { get; set; }

        protected IEnumerable<OkulMezunBilgisi> TumMezuniyetBilgileriniGetir()
        {
            MezunBilgileri = MezunBilgisi.GetAll();

            return MezunBilgileri;

        }
        public Dictionary<EgitimDurumu, string> EgitimDurumlari { get; set; }
        protected void TumEgitimDurumlariniGetir()
        {
            var list = new Dictionary<EgitimDurumu, string>();
            foreach (EgitimDurumu item in Enum.GetValues(typeof(EgitimDurumu)))
            {
                list.Add(item, item.TextEgitimDurumu());
            }
            EgitimDurumlari = list;
        }

        protected void Kayit()
        {
            MezunBilgisi.Add(okulMezunBilgisi);
        }
        protected override void OnParametersSet()
        {
            if (MezunId != 0)
            {
                Title = "Duzenle";
                okulMezunBilgisi = MezunBilgisi.Get(MezunId);
            }
        }

        protected void SilmeyiOnayla(int MezunId)
        {
            ModalDialog.Open();
            okulMezunBilgisi = MezunBilgileri.FirstOrDefault(x => x.Id == MezunId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (okulMezunBilgisi.Id == 0)
                return;

            MezunBilgisi.Remove(okulMezunBilgisi.Id);
            okulMezunBilgisi = new OkulMezunBilgisi();
            TumMezuniyetBilgileriniGetir();
            TumEgitimDurumlariniGetir();
        }

        protected override Task OnInitializedAsync()
        {
            TumMezuniyetBilgileriniGetir();
            TumEgitimDurumlariniGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            okulMezunBilgisi = null;

            UrlNavigationManager.NavigateTo("/mezuniyet/ekle");
        }


        [Inject]
        public IJSRuntime JsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("dataTables");
            }
        }
    }
}
