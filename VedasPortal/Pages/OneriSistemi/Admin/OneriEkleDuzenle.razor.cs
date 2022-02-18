using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.Oneri;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.OneriSistemi.Admin
{
    public class OneriModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Oneri> OneriServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int OneriId { get; set; }

        protected string Title = "Ekle";
        public Oneri oneri = new Oneri();

        public Dosya OneriDosya = new Dosya();

        protected IEnumerable<Oneri> Oneriler { get; set; }

        protected IEnumerable<Oneri> TumOnerileriGetir()
        {
            Oneriler = OneriServisi.GetAll();
            return Oneriler;

        }
        public Dictionary<OnemDerecesi, string> OnemDereceleri { get; set; }
        protected void TumDereceleriGetir()
        {
            var list = new Dictionary<OnemDerecesi, string>();
            foreach (OnemDerecesi item in Enum.GetValues(typeof(OnemDerecesi)))
            {
                list.Add(item, item.TextOnemDerecesi());
            }
            OnemDereceleri = list;
        }


        public Dictionary<Odul, string> Oduller { get; set; }
        protected void TumOdulleriGetir()
        {
            var list = new Dictionary<Odul, string>();
            foreach (Odul item in Enum.GetValues(typeof(Odul)))
            {
                list.Add(item, item.TextOdul());
            }
            Oduller = list;
        }


        public Dictionary<OneriKategori, string> OneriKategorileri { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<OneriKategori, string>();
            foreach (OneriKategori item in Enum.GetValues(typeof(OneriKategori)))
            {
                list.Add(item, item.TextOneriKategori());
            }
            OneriKategorileri = list;
        }

        protected void Kayit()
        {
            OneriServisi.AddUpdate(oneri);

        }
        protected override void OnParametersSet()
        {
            if (OneriId != 0)
            {
                Title = "Duzenle";
                oneri = OneriServisi.Get(OneriId);
                
            }
        }



        protected void SilmeyiOnayla(int oneriId)
        {
            ModalDialog.Open();
            oneri = Oneriler.FirstOrDefault(x => x.Id == oneriId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (oneri.Id == 0)
                return;

            OneriServisi.Remove(oneri.Id);
            oneri = new Oneri();
            TumKategorileriGetir();
            TumOnerileriGetir();
            TumDereceleriGetir();
            TumOdulleriGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumKategorileriGetir();
            TumOnerileriGetir();
            TumDereceleriGetir();
            TumOdulleriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            oneri = null;

            UrlNavigationManager.NavigateTo("/oneri/ekle");
        }


        [Inject]
        public IJSRuntime jsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await jsRun.InvokeVoidAsync("dataTables");
            }
        }
    }
}
