using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.HaberDuyuru;
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
        public HaberDuyuru haber = new HaberDuyuru();
         
        protected IEnumerable<HaberDuyuru> Haberler { get  ; set ; }

        protected IEnumerable<HaberDuyuru> TumHaberleriGetir()
        {
            Haberler = HaberServisi.GetAll();

            return Haberler;

        } 
        protected IEnumerable<HaberDuyuruKategori> Kategoriler { get ; set ; }

        protected IEnumerable<HaberDuyuruKategori> TumKategorileriGetir()
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
