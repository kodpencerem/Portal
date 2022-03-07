﻿using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz
{
    public class HaberModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<HaberDuyuru> HaberServisi { get; set; }
        protected IEnumerable<HaberDuyuru> haberler;

        public Dosya HaberDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumHeberleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<HaberDuyuru> TumHeberleriGetir()
        {
            haberler = HaberServisi.GetAll().AsQueryable().Include(s=>s.Dosya).ToList();
            return haberler;
        }
    }
}
