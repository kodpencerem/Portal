using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.KullaniciDurumlari
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

        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        protected async Task KayitAsync()
        {
            var authState = await State;
            var mezunBilgi = new OkulMezunBilgisi()
            {
                BaslamaTarihi = okulMezunBilgisi.BaslamaTarihi,
                KaydedenKullanici = authState.User.Identity.Name,
                EgitimDurumu = okulMezunBilgisi.EgitimDurumu,
                KayitTarihi = okulMezunBilgisi.KayitTarihi,
                MezuniyetTarihi= okulMezunBilgisi.MezuniyetTarihi,
                OkulAdi = okulMezunBilgisi.OkulAdi,
            };
            MezunBilgisi.Add(mezunBilgi);
            okulMezunBilgisi = new OkulMezunBilgisi();
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
        public string UserName;
        protected override async Task<Task> OnInitializedAsync()
        {
            var authState = await State;
            UserName = authState.User.Identity.Name;
            TumMezuniyetBilgileriniGetir();
            TumEgitimDurumlariniGetir();
            return Task.CompletedTask;
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
