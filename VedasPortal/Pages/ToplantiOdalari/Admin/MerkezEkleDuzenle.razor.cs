using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.ToplantiTakvimi;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.ToplantiOdalari.Admin
{
    public class ToplantiMerkeziModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<ToplantiMerkezi> ToplantiMerkeziServisi { get; set; }

        [Parameter]
        public int TMerkezId { get; set; }

        protected string Title = "Ekle";
        public ToplantiMerkezi toplantiMerkezi = new();


        protected IEnumerable<ToplantiMerkezi> ToplantiMerkezleri { get; set; }

        protected IEnumerable<ToplantiMerkezi> TumMerkezleriGetir()
        {
            ToplantiMerkezleri = ToplantiMerkeziServisi.GetAll();
            return ToplantiMerkezleri;
        }
        

        protected void Kayit()
        {

            ToplantiMerkeziServisi.Add(toplantiMerkezi);
            TumMerkezleriGetir();
            toplantiMerkezi = new ToplantiMerkezi();
        }
        protected override void OnParametersSet()
        {
            if (TMerkezId != 0 )
            {
                Title = "Duzenle";
                toplantiMerkezi = ToplantiMerkeziServisi.Get(TMerkezId);
            }
        }

        protected void SilmeyiOnayla(int TMerkezId)
        {
            ModalDialog.Open();

            toplantiMerkezi = ToplantiMerkezleri.FirstOrDefault(x => x.Id == TMerkezId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (toplantiMerkezi.Id == 0)
                return;
            ToplantiMerkeziServisi.Remove(toplantiMerkezi.Id);
            toplantiMerkezi = new ToplantiMerkezi();
            TumMerkezleriGetir();
        }

        protected override Task OnInitializedAsync()
        {
            TumMerkezleriGetir();
            return Task.CompletedTask;
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