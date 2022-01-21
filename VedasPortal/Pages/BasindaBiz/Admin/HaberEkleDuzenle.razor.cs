using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz.Admin
{
    public class HaberEkleDuzenleModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<Yayin> HaberServisi { get; set; }

        [Inject]
        public IBaseRepository<YayinKategori> HaberKategoriServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int haberId { get; set; }

        protected string Title = "Ekle";
        public Yayin haber = new Yayin();

        private IEnumerable<Yayin> haberler = new List<Yayin>();
        protected IEnumerable<Yayin> Haberler { get => haberler; set => haberler = value; }

        protected IEnumerable<Yayin> TumHaberleriGetir()
        {
            Haberler = HaberServisi.GetAll();

            return Haberler;

        }


        private IEnumerable<YayinKategori> kategoriler = new List<YayinKategori>();
        protected IEnumerable<YayinKategori> Kategoriler { get => kategoriler; set => kategoriler = value; }

        protected IEnumerable<YayinKategori> TumKategorileriGetir()
        {
            Kategoriler = HaberKategoriServisi.GetAll();
            
            return Kategoriler;

        }

        protected void HaberKayit()
        {

            HaberServisi.AddUpdate(haber);

        }

        protected string ImageBase64String { get; set; }
        protected string PreviewImagePath { get; set; }

        protected override void OnParametersSet()
        {
            if (haberId != 0)
            {
                Title = "Duzenle";
                haber = HaberServisi.Get(haberId);

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
            haber = new Yayin();
            TumHaberleriGetir();
        }


        protected override Task OnInitializedAsync()
        {
            TumHaberleriGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/haber/ekle");
        }

        public void Temizle()
        {
            haber = null;
            Cancel();
        }
    }
}
