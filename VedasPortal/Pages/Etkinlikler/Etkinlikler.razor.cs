using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Etkinlik;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Etkinlikler
{
    public class EtkinlikModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Etkinlik> EtkinlikServisi { get; set; }
        protected IEnumerable<Etkinlik> Etkinlikler;

        public ImageFile EtkinlikDosya { get; set; } = new ImageFile();

        protected override Task OnInitializedAsync()
        {
            TumEtkinlikleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Etkinlik> TumEtkinlikleriGetir()
        {
            Etkinlikler = EtkinlikServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return Etkinlikler;
        }

        protected string DialogGorunur { get; set; } = "none";

        public ModalComponent ModalDialog { get; set; }
    }
}
