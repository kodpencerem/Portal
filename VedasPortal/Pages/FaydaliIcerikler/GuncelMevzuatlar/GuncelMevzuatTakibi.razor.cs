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
        protected IEnumerable<Mevzuat> mevzuatlar { get; set; } = new List<Mevzuat>();

        public string SearchText = "";

        public List<Mevzuat> FilteredMevzuat => mevzuatlar.Where(
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
            mevzuatlar = MevzuatServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();

            return mevzuatlar;

        }
    }
}
