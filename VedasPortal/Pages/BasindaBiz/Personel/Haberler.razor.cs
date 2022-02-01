using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.BasindaBiz.Personel
{
    public class HaberModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Yayin> HaberServisi { get; set; }
        protected IEnumerable<Yayin> haberler;
              
        protected override Task OnInitializedAsync()
        {
            TumHeberleriGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Yayin> TumHeberleriGetir()
        {
            haberler = HaberServisi.GetAll();
            return haberler;
        }

        protected string DialogGorunur { get; set; } = "none";

        public ModalComponent ModalDialog { get; set; }      
    }
}
