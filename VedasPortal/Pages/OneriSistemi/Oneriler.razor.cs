using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Oneri;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.OneriSistemi
{
    public class OnerilerModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Oneri> Oneri { get; set; }
        protected IEnumerable<Oneri> Oneriler;
        public Oneri GetOneri = new();
        public ImageFile OneriDosya { get; set; }

        protected void PostLiked(bool isLiked)
        {
            GetOneri.Begeni = isLiked;
        }

        protected override Task OnInitializedAsync()
        {
            TumOnerileriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Oneri> TumOnerileriGetir()
        {
            Oneriler = Oneri.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();
            return Oneriler;
        }
    }
}
