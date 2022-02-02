using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.HaberDuyuru;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular
{
    public class DuyuruModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<HaberDuyuru> DuyuruServisi { get; set; }
        protected IEnumerable<HaberDuyuru> duyurular;



        protected string SearchString { get; set; }
        protected override Task OnInitializedAsync()
        {
            TumDuyurulariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<HaberDuyuru> TumDuyurulariGetir()
        {
            duyurular = DuyuruServisi.GetAll();

            return duyurular;

        }


        protected string DialogGorunur { get; set; } = "none";

        public ModalComponent ModalDialog { get; set; }

    }
}
