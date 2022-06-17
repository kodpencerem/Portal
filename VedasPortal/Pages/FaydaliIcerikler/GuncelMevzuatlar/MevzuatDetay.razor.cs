using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Mevzuat;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Pages.FaydaliIcerikler.GuncelMevzuatlar
{
    public partial class MevzuatDetay
    {
        [Inject]
        private IBaseRepository<Mevzuat> MevzuatServisi { get; set; }

        [Inject]
        public IBaseRepository<Dosya> DosyaServisi { get; set; }

        [Parameter]
        public int MevzuatId { get; set; }

        protected Mevzuat MevzuatDetayGetir { get; set; }
        public ImageFile MevzuatDetayDosya { get; set; }
        protected override Task OnInitializedAsync()
        {
            TumDosyalariGetir();            
            MevzuatDetayGetir = MevzuatServisi.Get(MevzuatId);
            return Task.CompletedTask;
        }

        public Dosya fileClass = new Dosya();
        public string pdfName = "";
        
        public void ShowOnCurrentPage(int fileId)
        {
            pdfName = string.Concat(fileClass.Files.SingleOrDefault(x => x.MevzuatId == fileId)?.Adi, ".",
                fileClass.Files.SingleOrDefault(x => x.MevzuatId == fileId)?.Uzanti);
        }

        protected IEnumerable<Dosya> Dosyalar { get; set; }

        protected IEnumerable<Dosya> TumDosyalariGetir()
        {
            Dosyalar = DosyaServisi.GetAll();
            return Dosyalar;

        }

        [Inject]
        public IJSRuntime JsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("lightGallery");
            }
        }
    }
}
