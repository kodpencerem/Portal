using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
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
        protected IBaseRepository<Rehber> Rehber { get; set; }
        protected IEnumerable<Rehber> rehber;

        protected List<Rehber> GetRehber = new();
        protected List<Rehber> SearchRehber = new();

        public Dosya RehberDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumRehberiGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Rehber> TumRehberiGetir()
        {
            rehber = Rehber.GetAll().AsQueryable().Include(s => s.ProfilResmi).ToList();
            return rehber;
        }


        protected string SearchString { get; set; }
        protected void FilterelemeYap()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                GetRehber = SearchRehber.Where(
                    x => x.Adi.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1 || x.Soyadi.IndexOf(SearchString,StringComparison.OrdinalIgnoreCase)!=-1).ToList();
            }
            else
            {
                GetRehber = SearchRehber;
            }
        }
    }
}
