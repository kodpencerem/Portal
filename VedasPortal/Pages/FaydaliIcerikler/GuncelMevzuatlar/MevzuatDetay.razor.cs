﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.GuncelMevzuatlar
{
    public partial class MevzuatDetay
    {
        [Inject]
        private IBaseRepository<Mevzuat> MevzuatServisi { get; set; }

        [Parameter]
        public int MevzuatId { get; set; }

        protected Mevzuat MevzuatDetayGetir { get; set; }
        public Dosya MevzuatDetayDosya { get; set; }
        protected override Task OnInitializedAsync()
        {
            MevzuatDetayGetir = MevzuatServisi.Get(MevzuatId);
            return Task.CompletedTask;
        }
    }
}
