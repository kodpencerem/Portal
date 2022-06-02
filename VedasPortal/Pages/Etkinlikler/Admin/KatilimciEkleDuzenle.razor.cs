using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Etkinlikler.Admin
{
    public class KatilimciModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<Katilimci> KatilimciServisi { get; set; }

        [Inject]
        public IBaseRepository<Etkinlik> EtkinlikServisi { get; set; }

        [Parameter]
        public int KatilimciId { get; set; }

        protected string Title = "Ekle";
        public Katilimci katilimci = new();

        public Dosya KatilimciDosya = new();

        protected IEnumerable<Katilimci> Katilimcilar { get; set; }

        protected IEnumerable<Katilimci> TumKatilimcilariGetir()
        {
            Katilimcilar = KatilimciServisi.GetAll();
            return Katilimcilar;

        }
        public Dictionary<EtkinlikKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<EtkinlikKategori, string>();
            foreach (EtkinlikKategori item in Enum.GetValues(typeof(EtkinlikKategori)))
            {
                list.Add(item, item.TextEtkinlik());
            }
            Kategoriler = list;
        }

        protected IEnumerable<Etkinlik> EtkinlikGetir { get; set; } = new List<Etkinlik>();
      
        protected IEnumerable<Etkinlik> TumEtkinlikleriGetir()
        {
            EtkinlikGetir = EtkinlikServisi.GetAll();

            return EtkinlikGetir;

        }

        protected void KatilimciKayit()
        {
            KatilimciServisi.Add(katilimci);
            TumKatilimcilariGetir();
            katilimci = new Katilimci();
        }
        protected override void OnParametersSet()
        {
            if (KatilimciId != 0)
            {
                Title = "Duzenle";
                katilimci = KatilimciServisi.Get(KatilimciId);

            }
        }



        protected void SilmeyiOnayla(int katilimciId)
        {
            ModalDialog.Open();
            katilimci = Katilimcilar.FirstOrDefault(x => x.Id == katilimciId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void KatilimciSil()
        {
            if (katilimci.Id == 0)
                return;

            KatilimciServisi.Remove(katilimci.Id);
            katilimci = new Katilimci();
            TumKatilimcilariGetir();
            TumEtkinlikleriGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumKatilimcilariGetir();
            TumKategorileriGetir();
            TumEtkinlikleriGetir();
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
