using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected List<Yayin> haberAra = new List<Yayin>();
        protected Yayin haber = new Yayin();

        protected string SearchString { get; set; }
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

        protected void HaberFilterelemeYap()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                haberler = haberAra.Where(x => x.Adi.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                haberler = haberAra;
            }
        }
        protected string dialogGorunur { get; set; } = "none";

        public ModalComponent modalDialog { get; set; }

    }
}
