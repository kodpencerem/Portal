﻿using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Models.Oneri;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.OneriSistemi
{
    public class OnerilerModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Oneri> Oneri { get; set; }
        protected IEnumerable<Oneri> Oneriler;

        protected override Task OnInitializedAsync()
        {
            TumOnerileriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Oneri> TumOnerileriGetir()
        {
            Oneriler = Oneri.GetAll();
            return Oneriler;
        }
    }
}