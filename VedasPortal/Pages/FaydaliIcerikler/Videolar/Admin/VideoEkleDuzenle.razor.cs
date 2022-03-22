using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.Video;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Videolar.Admin
{
    public class VideoEklemeModeli : ComponentBase
    {

        [Inject]
        public IBaseRepository<Video> VideoServisi { get; set; }

        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }

        [Parameter]
        public int VideoId { get; set; }

        protected string Title = "Ekle";
        public Video video = new();

        public Dosya VideoDosya = new();

        protected IEnumerable<Video> Videolar { get; set; }

        protected IEnumerable<Video> TumVideolariGetir()
        {
            Videolar = VideoServisi.GetAll();
            return Videolar;

        }
        public Dictionary<VideoKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<VideoKategori, string>();
            foreach (VideoKategori item in Enum.GetValues(typeof(VideoKategori)))
            {
                list.Add(item, item.TextVideo());
            }
            Kategoriler = list;
        }

        public Dictionary<Birimler, string> Birimler { get; set; }
        protected void TumBirimleriGetir()
        {
            var list = new Dictionary<Birimler, string>();
            foreach (Birimler item in Enum.GetValues(typeof(Birimler)))
            {
                list.Add(item, item.TextBirimler());
            }
            Birimler = list;
        }

        protected void Kayit()
        {
            VideoServisi.Add(video);

            VideoDosya.Yolu = video.Dosya?.Yolu;


        }
        protected override void OnParametersSet()
        {
            if (VideoId != 0)
            {
                Title = "Duzenle";
                video = VideoServisi.Get(VideoId);
                VideoDosya.Yolu = video.Dosya.Yolu;
            }
        }



        protected void SilmeyiOnayla(int videoId)
        {
            ModalDialog.Open();
            video = Videolar.FirstOrDefault(x => x.Id == videoId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (video.Id == 0)
                return;

            VideoServisi.Remove(video.Id);
            video = new Video();
            TumVideolariGetir();
            TumBirimleriGetir();
        }



        protected override Task OnInitializedAsync()
        {
            TumBirimleriGetir();
            TumVideolariGetir();
            TumKategorileriGetir();
            return Task.CompletedTask;
        }

        public void Temizle()
        {
            video = null;

            UrlNavigationManager.NavigateTo("/video/ekle");
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
