using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler
{
    public class EgitimlerModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Egitim> EgitimServisi { get; set; }

        protected IEnumerable<Egitim> EgitimleriGetir { get; set; } = new List<Egitim>();
     
        public string SearchText = "";
        protected PersonelDurum PersonelDurum { get; set; }
        public List<Egitim> FilteredEgitim => EgitimleriGetir.Where(
            x => x.Adi.ToLower().Contains(SearchText.ToLower())
            || x.Aciklama.ToLower().Contains(SearchText.ToLower())
            ).ToList();

        public ImageFile EgitimDosya { get; set; } = new ImageFile();
        
        protected override Task OnInitializedAsync()
        {
            TumEgitimleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Egitim> TumEgitimleriGetir()
        {
            EgitimleriGetir = EgitimServisi.GetAll();
            return EgitimleriGetir;
        }

        
    }
}
