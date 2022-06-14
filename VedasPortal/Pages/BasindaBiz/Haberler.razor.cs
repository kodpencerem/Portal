using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz
{
    public class HaberModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<HaberDuyuru> HaberServisi { get; set; }
        protected IEnumerable<HaberDuyuru> haberler;

        public ImageFile HaberDosya { get; set; } = new ImageFile();

        protected override Task OnInitializedAsync()
        {
            TumHaberleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<HaberDuyuru> TumHaberleriGetir()
        {
            haberler = HaberServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return haberler;
        }
    }
}
