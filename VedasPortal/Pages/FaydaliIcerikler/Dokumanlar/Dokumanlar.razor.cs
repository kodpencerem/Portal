using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar
{
    public class DosyaModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Dosya> Dokuman { get; set; }
        protected IEnumerable<Dosya> Dokumanlar { get; set; } = new List<Dosya>();


        public string SearchText = "";

        public List<Dosya> FilteredDokuman => Dokumanlar.Where(
             x => x.Adi.ToLower().Contains(SearchText.ToLower())
            ).ToList();

        protected override Task OnInitializedAsync()
        {
            TumDosyalariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Dosya>TumDosyalariGetir()
        {
            Dokumanlar = Dokuman.GetAll();
            return Dokumanlar;
        }      
    }
}
