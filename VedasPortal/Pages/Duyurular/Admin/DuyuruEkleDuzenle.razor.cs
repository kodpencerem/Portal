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

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<HaberDuyuru> DuyuruServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int DuyuruId { get; set; }

        protected string Title = "Ekle";
        public HaberDuyuru duyuru = new();

        protected IEnumerable<HaberDuyuru> Duyurular { get; set; }

        protected IEnumerable<HaberDuyuru> TumDuyurulariGetir()
        {
            Duyurular = DuyuruServisi.GetAll();

            return Duyurular;

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
            DuyuruServisi.AddUpdate(duyuru);
            
        }
        protected override void OnParametersSet()
        {
            if (DuyuruId != 0)
            {
                Title = "Duzenle";
                duyuru = DuyuruServisi.Get(DuyuruId);
                //DuyuruDosya = duyuru.Dosya.FirstOrDefault();

            }
        }



        protected void SilmeyiOnayla(int duyuruId)
        {
            ModalDialog.Open();
            duyuru = Duyurular.FirstOrDefault(x => x.Id == duyuruId);
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


        public Dosya DuyuruDosya { get; set; } = new Dosya();
        protected override Task OnInitializedAsync()
        {
            TumDuyurulariGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            duyuru = null;

            UrlNavigationManager.NavigateTo("/duyuru/ekle");
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
