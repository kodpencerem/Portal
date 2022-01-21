using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DKategoriEkleDuzenle : ComponentBase
    {
        [Inject]
        public IBaseRepository<YayinKategori> YayinKategorisi { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        protected IEnumerable<YayinKategori> yayinKategorileri = new List<YayinKategori>();

        [Parameter]
        public int kategoriId { get; set; }
        protected string Title = "Ekle";
        public YayinKategori duyuruKategori = new YayinKategori();       
        protected override void OnParametersSet()
        {
            if (kategoriId != 0)
            {
                Title = "Duzenle";
                duyuruKategori = YayinKategorisi.Get(kategoriId);
                
            }
        }

        protected void KategoriKayit()
        {
            YayinKategorisi.AddUpdate(duyuruKategori);
            Cancel();
        }

        protected override Task OnInitializedAsync()
        {
            TumDuyurulariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<YayinKategori> TumDuyurulariGetir()
        {
            yayinKategorileri = YayinKategorisi.GetAll();
            return yayinKategorileri;

        }

        protected string DialogGorunur { get; set; } = "none";
        protected void SilmeyiOnayla(int duyuruId)
        {
            ModalDialog.Open();
            duyuruKategori = yayinKategorileri.FirstOrDefault(x => x.Id == duyuruId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected void DuyuruSil()
        {
            if (duyuruKategori.Id == 0)
                return;

            YayinKategorisi.Remove(duyuruKategori.Id);
            duyuruKategori = new YayinKategori();
            TumDuyurulariGetir();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/duyuru/kategori/ekle");
            
        }

        public void Temizle()
        {
            this.duyuruKategori = null;
            Cancel();
        }
    }
}
