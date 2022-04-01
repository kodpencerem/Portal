using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler
{
    public class EgitimlerModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Egitim> EgitimServisi { get; set; }
        protected IEnumerable<Egitim> EgitimleriGetir;

        public Dosya EgitimDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumEgitimleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Egitim> TumEgitimleriGetir()
        {
            EgitimleriGetir = EgitimServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return EgitimleriGetir;
        }       
    }
}
