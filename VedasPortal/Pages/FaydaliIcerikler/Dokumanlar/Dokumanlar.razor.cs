using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.Dosya;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VedasPortal.Pages.BasindaBiz
{
    public class HaberModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<HaberDuyuru>
    HaberServisi
        { get; set; }
        protected IEnumerable<HaberDuyuru>
            haberler;

        public Dosya HaberDosya { get; set; } = new Dosya();

        protected override Task OnInitializedAsync()
        {
            TumHeberleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<HaberDuyuru>
            TumHeberleriGetir()
        {
            haberler = HaberServisi.GetAll().AsQueryable().Include(s => s.Dosya).ToList();
            return haberler;
        }

        protected string DialogGorunur { get; set; } = "none";

        public ModalComponent ModalDialog { get; set; }
    }
}
