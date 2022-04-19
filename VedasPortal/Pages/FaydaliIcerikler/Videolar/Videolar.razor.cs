using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
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
        protected IEnumerable<Video> VideoGetir;
        protected Dosya VideoDosya { get; set; } = new();

        protected override Task OnInitializedAsync()
        {
            TumVideolariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Video> TumVideolariGetir()
        {
            VideoGetir = Video.GetAll();
            return VideoGetir;
        }       
    }
}
