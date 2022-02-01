using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.Duyurular.Personel
{
    public class DuyuruModeli : ComponentBase
    {
        [Inject]
        protected IBaseRepository<Yayin> DuyuruServisi { get; set; }
        protected IEnumerable<Yayin> duyurular;
        
        
        
        protected string SearchString { get; set; }
        protected override Task OnInitializedAsync()
        {
            TumDuyurulariGetir();
            return Task.CompletedTask;
        }

        protected IEnumerable<Yayin> TumDuyurulariGetir()
        {
            duyurular = DuyuruServisi.GetAll();
            
            return duyurular;

        }

        
        protected string DialogGorunur { get; set; } = "none";

        public ModalComponent ModalDialog { get; set; }

    }
}
