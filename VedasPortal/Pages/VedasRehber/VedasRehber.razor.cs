using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.VedasRehber
{
    public class VedasRehberModel : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Rehber> RehberServisi { get; set; }
        protected IEnumerable<Rehber> Rehber { get; set; } = new List<Rehber>();

        public string SearchText = "";

        public List<Rehber> FilteredRehber => Rehber.Where(
            x => x.Adi.ToLower().Contains(SearchText.ToLower())
            || x.Soyadi.ToLower().Contains(SearchText.ToLower())
            || x.Unvani.ToLower().Contains(SearchText.ToLower())
            || x.TelefonNo.ToString().Contains(SearchText.ToLower())
            ).ToList();


        public ImageFile RehberDosya { get; set; } = new ImageFile();

        protected override Task OnInitializedAsync()
        {
            TumRehberiGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Rehber> TumRehberiGetir()
        {
            Rehber = RehberServisi.GetAll()
                           .AsQueryable()
                           .Include(s => s.ImageFile)
                           .ToList();
            return Rehber;
        }
    }
}
