using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Models;
using VedasPortal.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.VedasRehber
{
    public class VedasRehberModel : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Rehber> HaberServisi { get; set; }
        protected IEnumerable<Rehber> rehber;

        public Dosya RehberDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumRehberiGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Rehber> TumRehberiGetir()
        {
            rehber = HaberServisi.GetAll().AsQueryable().Include(s => s.ProfilResmi).ToList();
            return rehber;
        }
    }
}
