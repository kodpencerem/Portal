using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Entities.Models.User;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.KullaniciDurumlari
{
    public class ProfilModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<KursVeSertifika> KursVeSertifika { get; set; }

        [Inject]
        public IBaseRepository<OkulMezunBilgisi> MezunBilgisi { get; set; }

        [Inject]
        public IBaseRepository<UzmanlikAlani> Uzmanliklar { get; set; }

        protected IEnumerable<UzmanlikAlani> UzmanlikAlani { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        public KursVeSertifika kursVeSertifika = new();

        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }

        public string UserName;

        [Parameter]
        public int KursId { get; set; }

        [Parameter]
        public int MezunId { get; set; }

        protected IEnumerable<KursVeSertifika> KursVeSertifikalar { get; set; }

        protected IEnumerable<KursVeSertifika> TumKursVeSertifikalariGetir()
        {
            KursVeSertifikalar = KursVeSertifika.GetAll();

            return KursVeSertifikalar;

        }

        public OkulMezunBilgisi okulMezunBilgisi = new();

        protected IEnumerable<OkulMezunBilgisi> MezunBilgileri { get; set; }

        protected IEnumerable<OkulMezunBilgisi> TumMezuniyetBilgileriniGetir()
        {
            MezunBilgileri = MezunBilgisi.GetAll();

            return MezunBilgileri;

        }

        protected void KursSilmeyiOnayla(int KursId)
        {
            ModalDialog.Open();
            kursVeSertifika = KursVeSertifikalar.FirstOrDefault(x => x.Id == KursId);
        }
        protected void MezuniyetSilmeyiOnayla(int MezunId)
        {
            ModalDialog.Open();
            okulMezunBilgisi = MezunBilgileri.FirstOrDefault(x => x.Id == MezunId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void KursSil()
        {
            if (kursVeSertifika.Id == 0)
                return;
            KursVeSertifika.Remove(kursVeSertifika.Id);
            kursVeSertifika = new KursVeSertifika();
            TumKursVeSertifikalariGetir();
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
        protected void MezuniyetSil()
        {
            if (okulMezunBilgisi.Id == 0)
                return;

            MezunBilgisi.Remove(okulMezunBilgisi.Id);
            okulMezunBilgisi = new OkulMezunBilgisi();
            TumMezuniyetBilgileriniGetir();
            TumEgitimDurumlariniGetir();
        }

        protected override async Task<Task> OnInitializedAsync()
        {
            var authState = await State;
            PersonelDetayGetir = PersonelDurumServisi.Get(PersonelId);
            UserName = authState.User.Identity.Name;
            TumMezuniyetBilgileriniGetir();
            TumEgitimDurumlariniGetir();
            TumKursVeSertifikalariGetir();
            UzmanlikAlani = Uzmanliklar.GetAll();
            return Task.CompletedTask;
        }

        [Inject]
        private IBaseRepository<PersonelDurum> PersonelDurumServisi { get; set; }

        [Parameter]
        public int PersonelId { get; set; }
        public PersonelDurum PersonelDetayGetir { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        protected IEnumerable<PersonelDurum> Personeller { get; set; }

        protected IEnumerable<PersonelDurum> TumPersonelleriGetir()
        {
            Personeller = PersonelDurumServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();
            return Personeller;
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
