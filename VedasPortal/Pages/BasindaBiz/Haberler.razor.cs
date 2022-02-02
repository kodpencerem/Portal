using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz
{
    public class HaberModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<HaberDuyuru> HaberServisi { get; set; }
        protected IEnumerable<HaberDuyuru> haberler;

        protected override Task OnInitializedAsync()
        {
            TumHeberleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<HaberDuyuru> TumHeberleriGetir()
        {
            haberler = HaberServisi.GetAll();
            return haberler;
        }

        protected string DialogGorunur { get; set; } = "none";

        public ModalComponent ModalDialog { get; set; }
    }
}
