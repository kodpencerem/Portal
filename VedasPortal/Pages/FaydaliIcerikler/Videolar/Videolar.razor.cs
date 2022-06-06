using Blazored.Video;
using Blazored.Video.Support;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler
{
    public class VideoModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Vidyo> Video { get; set; }

        protected IEnumerable<Vidyo> VideoGetir { get; set; } = new List<Vidyo>();
        [Parameter]
        public Vidyo VideoDosya { get; set; } = new();

        public string SearchText = "";

        public List<Vidyo> FilteredVideo => VideoGetir.Where(
            x => x.Adi.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();

        protected override Task OnInitializedAsync()
        {
            TumVideolariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Vidyo> TumVideolariGetir()
        {
            VideoGetir = Video.GetAll();
            return VideoGetir;
        }

        public BlazoredVideo video;

        [Parameter]
        public string Width { get; set; }

        [Parameter]
        public string Heigth { get; set; }

        [Parameter]
        public string Src { get; set; }

        [Parameter]
        public string VideoBaslik { get; set; }

        [Parameter]
        public string Aciklama { get; set; }

        public void OnPlay(VideoState state)
        {
            var url = state?.CurrentSrc;
            // do something with this
        }
        public void OnTimeUpdate(VideoState state)
        {
            var url = state?.CurrentSrc;
            var currentTime = state?.CurrentTime;
            // do something with this
        }
    }
}
