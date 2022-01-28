using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<Yayin> DuyuruServisi { get; set; }

        [Inject]
        public IBaseRepository<YayinKategori> DuyuruKategoriServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int duyuruId { get; set; }

        protected string Title = "Ekle";
        public Yayin duyuru = new Yayin();
        
        private IEnumerable<Yayin> duyurularListesi = new List<Yayin>();
        protected IEnumerable<Yayin> DuyurularListesi { get => duyurularListesi; set => duyurularListesi = value; }

        protected IEnumerable<Yayin> TumDuyurulariGetir()
        {
            DuyurularListesi = DuyuruServisi.GetAll();

            return DuyurularListesi;

        }


        private IEnumerable<YayinKategori> kategoriler = new List<YayinKategori>();
        protected IEnumerable<YayinKategori> Kategoriler { get => kategoriler; set => kategoriler = value; }

        protected IEnumerable<YayinKategori> TumKategorileriGetir()
        {
            Kategoriler = DuyuruKategoriServisi.GetAll();

            return Kategoriler;

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
            duyuru = DuyurularListesi.FirstOrDefault(x => x.Id == duyuruId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void DuyuruSil()
        {
            if (duyuru.Id == 0)
                return;

            DuyuruServisi.Remove(duyuru.Id);
            duyuru = new Yayin();
            TumDuyurulariGetir();
        }

        
        protected override Task OnInitializedAsync()
        {
            TumDuyurulariGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
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
