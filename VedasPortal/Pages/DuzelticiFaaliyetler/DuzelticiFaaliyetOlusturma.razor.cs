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
        protected IEnumerable<DuzelticiFaaliyet> DuzelticiFaaliyet;

        protected override Task OnInitializedAsync()
        {
            TumFaaliyetleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<DuzelticiFaaliyet> TumFaaliyetleriGetir()
        {
            DuzelticiFaaliyet = DuzelticiFaaliyetler.GetAll().AsQueryable().Include(s => s.Resim).ToList();
            return DuzelticiFaaliyet;
        }       
    }
}
