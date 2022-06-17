using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Yorum;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.YorumYonetim.Admin
{
    public class YorumModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Yorum> YorumServisi { get; set; }
     
        [Parameter]
        public int YorumId { get; set; }

        protected string Title = "Ekle";
        public Yorum yorum = new();


        protected IEnumerable<Yorum> Yorumlar { get; set; }

        protected IEnumerable<Yorum> TumYorumlarilariGetir()
        {
            Yorumlar = YorumServisi.GetAll();
            return Yorumlar;

        }

        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        protected async Task KayitAsync()
        {
            var authState = await State;
            yorum.KaydedenKullanici = authState.User.Identity.Name;
            YorumServisi.Add(yorum);
            TumYorumlarilariGetir();
            yorum = new Yorum();
        }
        protected override void OnParametersSet()
        {
            if (YorumId != 0)
            {
                Title = "Duzenle";
                yorum = YorumServisi.Get(YorumId);

            }
        }



        protected void SilmeyiOnayla(int yorumId)
        {
            ModalDialog.Open();
            yorum = Yorumlar.FirstOrDefault(x => x.Id == yorumId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (yorum.Id == 0)
                return;

            YorumServisi.Remove(yorum.Id);
            yorum = new Yorum();
            TumYorumlarilariGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumYorumlarilariGetir();
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
