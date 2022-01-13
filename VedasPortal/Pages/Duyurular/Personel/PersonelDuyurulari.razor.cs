using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Services.DuyuruHaber;

namespace VedasPortal.Pages.Duyurular.Personel
{
    public class DuyuruIndexModel : ComponentBase
    {
        [Inject]
        protected DuyuruHaberService DuyuruService { get; set; }
        protected List<Yayin> duyuruListesi = new List<Yayin>();
        protected List<Yayin> duyuruAra = new List<Yayin>();
        protected Yayin duyuru = new Yayin();
        protected string SearchString { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await TumDuyurulariGetir();
        }

        protected async Task TumDuyurulariGetir()
        {
            duyuruListesi = await DuyuruService.TumunuGetir();
            duyuruAra = duyuruListesi;
        }

        protected void DuyuruFilterelemeYap()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                duyuruListesi = duyuruAra.Where(x => x.Adi.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                duyuruListesi = duyuruAra;
            }
        }
        protected string dialogGorunur { get; set; } = "none";

        public ModalComponent modalDialog { get; set; }

    }
}
