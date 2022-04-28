﻿using Microsoft.AspNetCore.Components;
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
        protected IEnumerable<Rehber> rehber;

        protected IEnumerable<Rehber> GetRehber= new List<Rehber>();
        protected IEnumerable<Rehber> SearchRehber = new List<Rehber>();

        public Dosya RehberDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumRehberiGetir();
            SearchRehber = GetRehber;
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


        protected string SearchString { get;set; }
        protected void FilterelemeYap()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                GetRehber = SearchRehber.Where(
                    x => x.Adi.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1 || 
                    x.Soyadi.IndexOf(SearchString,StringComparison.OrdinalIgnoreCase)!=-1).ToList();
            }
            else
            {
                GetRehber = SearchRehber;
            }
        }
    }
}
