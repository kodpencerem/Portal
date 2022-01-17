using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Services.DuyuruHaber;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruModel : ComponentBase
    {
        
        [Inject]
        protected DuyuruHaberService DuyuruService { get; set; }
        protected List<Yayin> duyurularListesi = new List<Yayin>();
        protected List<Yayin> duyuruAra = new List<Yayin>();
        protected Yayin duyuru = new Yayin();
        protected string SearchString { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await TumDuyurulariGetir();
        }

        protected async Task TumDuyurulariGetir()
        {
            duyurularListesi = await DuyuruService.TumunuGetir();
            duyuruAra = duyurularListesi;
        }

        protected void DuyuruFilterelemeYap()
        {
            if (!string.IsNullOrEmpty(SearchString))
            {
                duyurularListesi = duyuruAra.Where(
                    x => x.Adi.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
            else
            {
                duyurularListesi = duyuruAra;
            }
        }
        protected string DialogGorunur { get; set; } = "none";
        protected void SilmeyiOnayla(int duyuruId)
        {
            ModalDialog.Open();
            duyuru = duyurularListesi.FirstOrDefault(x => x.Id == duyuruId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected void DuyuruSil()
        {
            if (duyuru.Id == 0)
                return;

            DuyuruService.Sil(duyuru.Id);
            duyuru = new Yayin();
            TumDuyurulariGetir().Wait();
        }

       
    }
    
}
