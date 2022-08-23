using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Videolar
{
    public class VideoModel : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Dosya> Video { get; set; }

        protected IEnumerable<Dosya> VideoList { get; set; } = new List<Dosya>();
        protected Dosya VideoDosya { get; set; } = new();

        public string SearchText = "";

        public List<Dosya> FilteredVideo => VideoList.Where(
            x => x.Adi.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();

        protected override Task OnInitializedAsync()
        {
            TumVideolariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Dosya> TumVideolariGetir()
        {
            VideoList = Video.GetAll();
            return VideoList;
        }
    }
}
