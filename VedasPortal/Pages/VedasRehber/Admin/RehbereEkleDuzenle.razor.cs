using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.VedasRehber.Admin
{
    public class RehberModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Rehber> RehberServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int RehberId { get; set; }

        protected string Title = "Ekle";
        public Rehber rehber = new Rehber();

        protected IEnumerable<Rehber> Rehber { get; set; }

        protected IEnumerable<Rehber> TumRehberiGetir()
        {
            Rehber = RehberServisi.GetAll();

            return Rehber;

        }


        protected void Kayit()
        {
            RehberServisi.AddUpdate(rehber);

        }
        protected override void OnParametersSet()
        {
            if (RehberId != 0)
            {
                Title = "Duzenle";
                rehber = RehberServisi.Get(RehberId);
            }
        }



        protected void SilmeyiOnayla(int rehberId)
        {
            ModalDialog.Open();
            rehber = Rehber.FirstOrDefault(x => x.Id == rehberId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (rehber.Id == 0)
                return;

            RehberServisi.Remove(rehber.Id);
            rehber = new Rehber();
            TumRehberiGetir();
        }


        public Dosya RehberDosya { get; set; } = new Dosya();
        protected override Task OnInitializedAsync()
        {
            TumRehberiGetir();

            return Task.CompletedTask;
        }

        public void Temizle()
        {
            rehber = null;

            UrlNavigationManager.NavigateTo("/rehber/ekle");
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
