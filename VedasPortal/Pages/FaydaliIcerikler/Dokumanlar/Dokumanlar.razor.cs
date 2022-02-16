using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.Dosya;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar
{
    public class DosyaModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Dosya> HaberServisi
        { get; set; }
        protected IEnumerable<Dosya> Dokumanlar;

        public Dosya HaberDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumHeberleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Dosya>
            TumHeberleriGetir()
        {
            Dokumanlar = HaberServisi.GetAll();
            return Dokumanlar;
        }

        protected string DialogGorunur { get; set; } = "none";

        public ModalComponent ModalDialog { get; set; }
    }
}
