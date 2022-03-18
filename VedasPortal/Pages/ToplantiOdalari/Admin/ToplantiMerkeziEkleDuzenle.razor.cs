using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari.Admin
{
    public class ToplantiMerkeziModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<ToplantiMerkezi> ToplantiMerkezi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int TOdaMerkezId { get; set; }

        protected string Title = "Ekle";
        public ToplantiMerkezi TOdaMerkezi = new();

        protected IEnumerable<ToplantiMerkezi> ToplantiMerkezleri { get; set; }

        protected IEnumerable<ToplantiMerkezi> TumTMerkezleriGetir()
        {
            ToplantiMerkezleri = ToplantiMerkezi.GetAll();
            return ToplantiMerkezleri;
        }
        
        protected void Kayit()
        {
            ToplantiMerkezi.Add(TOdaMerkezi);

        }
        protected override void OnParametersSet()
        {
            if (TOdaMerkezId != 0)
            {
                Title = "Duzenle";
                TOdaMerkezi = ToplantiMerkezi.Get(TOdaMerkezId);
                //DuyuruDosya = duyuru.Dosya.FirstOrDefault();

            }
        }

        protected void SilmeyiOnayla(int TOdaMerkezId)
        {
            ModalDialog.Open();
            TOdaMerkezi = ToplantiMerkezleri.FirstOrDefault(x => x.Id == TOdaMerkezId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (TOdaMerkezi.Id == 0)
                return;

            ToplantiMerkezi.Remove(TOdaMerkezi.Id);
            TOdaMerkezi = new ToplantiMerkezi();
            TumTMerkezleriGetir();
        }

        protected override Task OnInitializedAsync()
        {
            TumTMerkezleriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            TOdaMerkezi = null;

            UrlNavigationManager.NavigateTo("/toplantimerkezi/ekle");
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
