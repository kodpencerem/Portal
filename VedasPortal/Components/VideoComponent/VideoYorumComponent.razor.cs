using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Yorum;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Components.VideoComponent
{
    public partial class VideoYorumComponent
    {
        [Inject]
        private IBaseRepository<Yorum> YorumServisi { get; set; }
        public Yorum Yorum { get; set; } = new();

        private Vidyo VideoYorumGetir { get; set; } = new();

        protected string Title = "Ekle";

        [Parameter]
        public IEnumerable<Yorum> Yorumlar { get; set; }

        protected IEnumerable<Yorum> TumYorumlariGetir()
        {
            Yorumlar = YorumServisi.GetAll();
            return Yorumlar;
        }

        protected override Task OnInitializedAsync()
        {
            TumYorumlariGetir();
            return Task.CompletedTask;
        }

        public void InsertComment()
        {
            if(VideoYorumGetir.Id != 0)
            {
                var yorum = new Yorum()
                {
                    Aciklama = Yorum.Aciklama,
                    VidyoId = VideoYorumGetir.Id
                };
                YorumServisi.Add(yorum);
                TumYorumlariGetir();
                VideoYorumGetir = new Vidyo();
            }
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
