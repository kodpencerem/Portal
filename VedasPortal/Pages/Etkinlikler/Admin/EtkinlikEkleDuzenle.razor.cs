using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Etkinlikler.Admin
{
    public class EtkinlikModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Etkinlik> EtkinlikServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int EtkinlikId { get; set; }

        protected string Title = "Ekle";
        public Etkinlik etkinlik = new();

        public Dosya EtkinlikDosya = new();

        protected IEnumerable<Etkinlik> Etkinlikler { get; set; }

        protected IEnumerable<Etkinlik> TumEtkinlikleriGetir()
        {
            Etkinlikler = EtkinlikServisi.GetAll();
            return Etkinlikler;

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

        public Dictionary<KatilimciKategori, string> KatilacakPersonel { get; set; }
        protected void TumKatilimcilariGetir()
        {
            var list = new Dictionary<KatilimciKategori, string>();
            foreach (KatilimciKategori item in Enum.GetValues(typeof(KatilimciKategori)))
            {
                list.Add(item, item.TextKatilimci());
            }
            KatilacakPersonel = list;
        }

        protected void EtkinlikKayit()
        {
            EtkinlikServisi.AddUpdate(etkinlik);

        }
        protected override void OnParametersSet()
        {
            if (EtkinlikId != 0)
            {
                Title = "Duzenle";
                etkinlik = EtkinlikServisi.Get(EtkinlikId);
                
            }
        }



        protected void SilmeyiOnayla(int etkinlikId)
        {
            ModalDialog.Open();
            etkinlik = Etkinlikler.FirstOrDefault(x => x.Id == etkinlikId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void EtkinlikSil()
        {
            if (etkinlik.Id == 0)
                return;

            EtkinlikServisi.Remove(etkinlik.Id);
            etkinlik = new Etkinlik();
            TumEtkinlikleriGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumEtkinlikleriGetir();
            TumKategorileriGetir();
            TumKatilimcilariGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            etkinlik = null;

            UrlNavigationManager.NavigateTo("/etkinlik/ekle");
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
