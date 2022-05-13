using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.DuzelticiFaaliyet;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.DuzelticiFaaliyetler
{
    public class DuzelticiFaaliyetlerModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<DuzelticiFaaliyet> DuzelticiFaaliyetler { get; set; }
        protected IEnumerable<DuzelticiFaaliyet> DuzelticiFaaliyet { get; set; } = new List<DuzelticiFaaliyet>();

        public string SearchText = "";

        public List<DuzelticiFaaliyet> FilteredFaaliyet => DuzelticiFaaliyet.Where(
            x => x.FaaliyetGurupAdi.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();


        protected override Task OnInitializedAsync()
        {
            TumFaaliyetleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<DuzelticiFaaliyet> TumFaaliyetleriGetir()
        {
            DuzelticiFaaliyet = DuzelticiFaaliyetler.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return DuzelticiFaaliyet;
        }       
    }
}
