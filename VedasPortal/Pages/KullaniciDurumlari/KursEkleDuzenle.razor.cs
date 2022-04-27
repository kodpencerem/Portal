using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Video;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Kullanici
{
    public class KursEklemeModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<KursVeSertifika> KursVeSertifika { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int KursId { get; set; }

        protected string Title = "Ekle";
        public KursVeSertifika kursVeSertifika = new();
     
        protected IEnumerable<KursVeSertifika> Kurslar { get; set; }

        protected IEnumerable<KursVeSertifika> TumKurslariGetir()
        {
            Kurslar = KursVeSertifika.GetAll();
            return Kurslar;

        }
        
        protected void Kayit()
        {
            KursVeSertifika.Add(kursVeSertifika);
        }
        protected override void OnParametersSet()
        {
            if (KursId != 0)
            {
                Title = "Duzenle";
                kursVeSertifika = KursVeSertifika.Get(KursId);
            }
        }

        protected void SilmeyiOnayla(int KursId)
        {
            ModalDialog.Open();
            kursVeSertifika = Kurslar.FirstOrDefault(x => x.Id == KursId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (kursVeSertifika.Id == 0)
                return;

            KursVeSertifika.Remove(kursVeSertifika.Id);
            kursVeSertifika = new KursVeSertifika();
            TumKurslariGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumKurslariGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            kursVeSertifika = null;

            UrlNavigationManager.NavigateTo("/Profil");
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
