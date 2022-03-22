using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz.Admin
{
    public class HaberEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<HaberDuyuru> HaberServisi { get; set; } 

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int HaberId { get; set; }

        protected string Title = "Ekle";
        public HaberDuyuru haber = new();

        public Dosya HaberDosya = new();
        

        protected IEnumerable<HaberDuyuru> Haberler { get  ; set ; }

        protected IEnumerable<HaberDuyuru> TumHaberleriGetir()
        {
            Haberler = HaberServisi.GetAll();
            return Haberler;

        }
        public Dictionary<HaberDuyuruKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<HaberDuyuruKategori, string>();
            foreach (HaberDuyuruKategori item in Enum.GetValues(typeof(HaberDuyuruKategori)))
            {
                list.Add(item, item.TextHaberDuyuru());
            }
            Kategoriler = list;
        }

        protected void HaberKayit()
        {

            //var dosya = haber.Dosya.Select(x => new Dosya
            //{
            //    Id = x.Id,
            //    Adi = x.Adi,
            //    Aciklama = x.Aciklama,
            //    Boyutu = x.Boyutu,
            //    Yolu = x.Yolu,
            //    DuzenlemeTarihi = x.DuzenlemeTarihi,
            //    DuzenleyenKullanici = x.DuzenleyenKullanici,
            //    KaydedenKullanici = x.KaydedenKullanici,
            //    KayitTarihi = x.KayitTarihi,
            //    Uzanti = x.Uzanti

            //});
            //haber.Dosya = dosya.ToArray();
            
            HaberServisi.Add(haber);
        }
        protected override void OnParametersSet()
        {
            if (HaberId != 0)
            {
                Title = "Duzenle";
                haber = HaberServisi.Get(HaberId);               
            }
        }



        protected void SilmeyiOnayla(int haberId)
        {
            ModalDialog.Open();
            haber = Haberler.FirstOrDefault(x => x.Id == haberId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void HaberSil()
        {
            if (haber.Id == 0)
                return;

            HaberServisi.Remove(haber.Id);
            haber = new HaberDuyuru();
            TumHaberleriGetir();
        }


        
        protected override Task OnInitializedAsync()
        {
            TumHaberleriGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            haber = null;

            UrlNavigationManager.NavigateTo("/haber/ekle");
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
