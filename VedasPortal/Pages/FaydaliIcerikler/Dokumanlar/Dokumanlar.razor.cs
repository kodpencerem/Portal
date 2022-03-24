using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar
{
    public class DosyaModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Dosya> Dokuman { get; set; }
        protected IEnumerable<Dosya> Dokumanlar;
      
        protected override Task OnInitializedAsync()
        {
            TumDosyalariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Dosya>TumDosyalariGetir()
        {
            Dokumanlar = Dokuman.GetAll();
            return Dokumanlar;
        }      
    }
}
