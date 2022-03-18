using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar.Admin
{
    public class DosyaModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<Dosya> DosyaServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int DosyaId { get; set; }

        protected string Title = "Ekle";
        public Dosya dosya = new();

        

        protected IEnumerable<Dosya> Dosyalar { get; set; }

        protected IEnumerable<Dosya> TumDosyalariGetir()
        {
            Dosyalar = DosyaServisi.GetAll();
            return Dosyalar;

        }
        public Dictionary<DosyaKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<DosyaKategori, string>();
            foreach (DosyaKategori item in Enum.GetValues(typeof(DosyaKategori)))
            {
                list.Add(item, item.TextDosya());
            }
            Kategoriler = list;
        }

        protected void Kayit()
        {
            DosyaServisi.Add(dosya);

            

        }
        protected override void OnParametersSet()
        {
            if (DosyaId != 0)
            {
                Title = "Duzenle";
                dosya = DosyaServisi.Get(DosyaId);
            }
        }



        protected void SilmeyiOnayla(int dosyaId)
        {
            ModalDialog.Open();
            dosya = Dosyalar.FirstOrDefault(x => x.Id == dosyaId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (dosya.Id == 0)
                return;

            DosyaServisi.Remove(dosya.Id);
            dosya = new Dosya();
            TumDosyalariGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumDosyalariGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            dosya = null;

            UrlNavigationManager.NavigateTo("/dosya/ekle");
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
