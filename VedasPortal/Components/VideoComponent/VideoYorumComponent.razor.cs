using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Video;
using VedasPortal.Entities.Models.Yorum;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.KullaniciDurumlari
{
    public class VideoYorumComponent : ComponentBase
    {

        [Inject]
        private IBaseRepository<Yorum> _yorum { get; set; }
        public Yorum yorum { get; set; } = new();

        private Video videoGetir { get; set; } = new();

        protected string Title = "Ekle";

        [Parameter]
        public IEnumerable<Yorum> Yorumlar { get; set; }

        protected IEnumerable<Yorum> TumYorumlariGetir()
        {
            Yorumlar = _yorum.GetAll();
            return Yorumlar;
        }

        protected override Task OnInitializedAsync()
        {
            TumYorumlariGetir();
            return Task.CompletedTask;
        }

        public void InsertComment()
        {
            var yorumEkle = new Yorum()
            {
                Aciklama = yorum.Aciklama,
                VideoId = videoGetir.Id
            };

            _yorum.Add(yorumEkle);
            yorum.Aciklama = string.Empty;
        }
    }
}
