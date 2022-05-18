using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Video;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler
{
    public class VideoModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<VideoClass> Video { get; set; }

        protected IEnumerable<VideoClass> VideoGetir { get; set; } = new List<VideoClass>();
        protected Dosya VideoDosya { get; set; } = new();

        public string SearchText = "";

        public List<VideoClass> FilteredVideo => VideoGetir.Where(
            x => x.Baslik.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();

        protected override Task OnInitializedAsync()
        {
            TumVideolariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<VideoClass> TumVideolariGetir()
        {
            VideoGetir = Video.GetAll();
            return VideoGetir;
        }       
    }
}
