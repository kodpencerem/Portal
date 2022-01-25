using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected List<Yayin> duyuruAra = new List<Yayin>();
        protected Yayin duyuru = new Yayin();
        
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

        protected void DuyuruFilterelemeYap()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                duyurular = duyuruAra.Where(x => x.Adi.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                duyurular = duyuruAra;
            }
        }
        protected string dialogGorunur { get; set; } = "none";

        public ModalComponent modalDialog { get; set; }

    }
}
