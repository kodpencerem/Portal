using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.GuncelMevzuatlar
{
    public class MevzuatModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Mevzuat> MevzuatServisi { get; set; }
        protected IEnumerable<Mevzuat> Mevzuatlar { get; set; } = new List<Mevzuat>();

        public string SearchText = "";

        public List<Mevzuat> FilteredMevzuat => Mevzuatlar.Where(
            x => x.Adi.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();


        protected override Task OnInitializedAsync()
        {
            TumMevzuatlariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Mevzuat> TumMevzuatlariGetir()
        {
            Mevzuatlar = MevzuatServisi.GetAll().AsQueryable().Include(s => s.ImageFile).ToList();

            return Mevzuatlar;

        }
    }
}
