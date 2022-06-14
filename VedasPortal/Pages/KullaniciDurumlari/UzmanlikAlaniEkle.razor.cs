using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.User;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.KullaniciDurumlari
{
    public class UzmanlikAlaniModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<UzmanlikAlani> UzmanlikAlaniServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int UzmanlikId { get; set; }

        protected string Title = "Ekle";
        public UzmanlikAlani uzmanlikAlani = new();

        public ApplicationUser ApplicationUser { get; set; }

        protected IEnumerable<UzmanlikAlani> UzmanlikAlanlari { get; set; }

        protected IEnumerable<UzmanlikAlani> TumUzmanliklariGetir()
        {
            UzmanlikAlanlari = UzmanlikAlaniServisi.GetAll();
            return UzmanlikAlanlari;

        }

        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }

        protected async Task KayitAsync()
        {
            var authState = await State;
            var uzmanlik = new UzmanlikAlani()
            {
                Adi = uzmanlikAlani.Adi,
                UzmanlikSeviyesi = uzmanlikAlani.UzmanlikSeviyesi,
                KaydedenKullanici = authState.User.Identity.Name
            };
            UzmanlikAlaniServisi.Add(uzmanlik);
            uzmanlikAlani = new UzmanlikAlani();
        }
        protected override void OnParametersSet()
        {
            if (UzmanlikId != 0)
            {
                Title = "Duzenle";
                uzmanlikAlani = UzmanlikAlaniServisi.Get(UzmanlikId);
            }
        }

        protected void SilmeyiOnayla(int UzmanlikId)
        {
            ModalDialog.Open();
            uzmanlikAlani = UzmanlikAlanlari.FirstOrDefault(x => x.Id == UzmanlikId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (uzmanlikAlani.Id == 0)
                return;

            UzmanlikAlaniServisi.Remove(uzmanlikAlani.Id);
            uzmanlikAlani = new UzmanlikAlani();
            TumUzmanliklariGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumUzmanliklariGetir();
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
