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
        protected IBaseRepository<Video> Video { get; set; }

        protected IEnumerable<Video> VideoGetir { get; set; } = new List<Video>();
        protected Dosya VideoDosya { get; set; } = new();

        public string SearchText = "";

        public List<Video> FilteredVideo => VideoGetir.Where(
            x => x.Baslik.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();

        protected override Task OnInitializedAsync()
        {
            TumVideolariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Video> TumVideolariGetir()
        {
            VideoGetir = Video.GetAll().AsQueryable().Include(d=>d.Dosya).ToList();
            return VideoGetir;
        }       
    }
}
