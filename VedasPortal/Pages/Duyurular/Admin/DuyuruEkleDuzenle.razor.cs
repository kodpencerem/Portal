using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<HaberDuyuru> DuyuruServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int duyuruId { get; set; }

        protected string Title = "Ekle";
        public HaberDuyuru duyuru = new HaberDuyuru();

        protected IEnumerable<HaberDuyuru> DuyurularListesi { get; set; }

        protected IEnumerable<HaberDuyuru> TumDuyurulariGetir()
        {
            DuyurularListesi = DuyuruServisi.GetAll();

            return DuyurularListesi;

        }
         
        public Dictionary<HaberDuyuruKategori, string> Kategoriler { get; set; }
        protected  void TumKategorileriGetir()
        {
            var list = new Dictionary<HaberDuyuruKategori, string>();
            foreach (HaberDuyuruKategori item in Enum.GetValues(typeof(HaberDuyuruKategori)))
            {
                list.Add(item, item.TextHaberDuyuru());
            }
            Kategoriler= list; 
        }

        protected void DuyuruKayit()
        {
            DuyuruServisi.AddUpdate(duyuru);

        }

        protected string ImageBase64String { get; set; }
        protected string PreviewImagePath { get; set; }

        protected override void OnParametersSet()
        {
            if (duyuruId != 0)
            {
                Title = "Duzenle";
                duyuru = DuyuruServisi.Get(duyuruId);

            }
        }



        protected void SilmeyiOnayla(int duyuruId)
        {
            ModalDialog.Open();
            duyuru = DuyurularListesi.Where(x => x.Id == duyuruId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void DuyuruSil()
        {
            if (duyuru.Id == 0)
                return;

            DuyuruServisi.Remove(duyuru.Id);
            duyuru = new HaberDuyuru();
            TumDuyurulariGetir();
        }


        [Inject]
        public IJSRuntime jsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {

                TumDuyurulariGetir();
                TumKategorileriGetir();
                await jsRun.InvokeVoidAsync("dataTables");

            }
        }
        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/duyuru/ekle");
        }

        public void Temizle()
        {
            this.duyuru = null;
            Cancel();
        }
    }
}
