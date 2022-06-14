using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.KullaniciDurumlari
{
    public class KursEklemeModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<KursVeSertifika> KursVeSertifika { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int KursId { get; set; }

        protected string Title = "Ekle";
        public KursVeSertifika kursVeSertifika = new();

        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        public string UserName;
        protected IEnumerable<KursVeSertifika> Kurslar { get; set; }

        protected IEnumerable<KursVeSertifika> TumKurslariGetir()
        {
            Kurslar = KursVeSertifika.GetAll();
            return Kurslar;

        }

        protected async Task KayitAsync()
        {
            var authState = await State;
            var kursSertifika = new KursVeSertifika()
            {
               
                KaydedenKullanici = authState.User.Identity.Name,
                KayitTarihi = kursVeSertifika.KayitTarihi,
                Aciklama = kursVeSertifika.Aciklama,
                BaslamaTarihi = kursVeSertifika.BaslamaTarihi,
                BitisTarihi = kursVeSertifika.BitisTarihi,
                GecerlilikSuresi = kursVeSertifika.GecerlilikSuresi,
                SertifikaBaslik = kursVeSertifika.SertifikaBaslik,
                SertifikaKodu = kursVeSertifika.SertifikaKodu,
                SertifikaUrlAdres = kursVeSertifika.SertifikaUrlAdres,
                SertifikaVerilisTarihi = kursVeSertifika.SertifikaVerilisTarihi,
                VerenKurum = kursVeSertifika.VerenKurum
            };
            KursVeSertifika.Add(kursSertifika);
            kursVeSertifika = new KursVeSertifika();
        }
        protected override void OnParametersSet()
        {
            if (KursId != 0)
            {
                Title = "Duzenle";
                kursVeSertifika = KursVeSertifika.Get(KursId);
            }
        }

        protected void SilmeyiOnayla(int KursId)
        {
            ModalDialog.Open();
            kursVeSertifika = Kurslar.FirstOrDefault(x => x.Id == KursId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (kursVeSertifika.Id == 0)
                return;

            KursVeSertifika.Remove(kursVeSertifika.Id);
            kursVeSertifika = new KursVeSertifika();
            TumKurslariGetir();
        }
        protected override async Task<Task> OnInitializedAsync()
        {
            var authState = await State;
            UserName = authState.User.Identity.Name;
            TumKurslariGetir();
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
