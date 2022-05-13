using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
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
        protected IBaseRepository<Rehber> Rehber { get; set; }
        protected IEnumerable<Rehber> rehber { get; set; } = new List<Rehber>();

        public string SearchText = "";

        public List<Rehber> FilteredRehber => rehber.Where(
            x => x.Adi.ToLower().Contains(SearchText.ToLower())
            || x.Soyadi.ToLower().Contains(SearchText.ToLower())
            || x.Unvani.ToLower().Contains(SearchText.ToLower())
            || x.TelefonNo.ToString().Contains(SearchText.ToLower())
            ).ToList();


        public Dosya RehberDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumRehberiGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Rehber> TumRehberiGetir()
        {
            rehber = Rehber.GetAll()
                           .AsQueryable()
                           .Include(s => s.Dosya)
                           .ToList();
            return rehber;
        }      
    }
}
