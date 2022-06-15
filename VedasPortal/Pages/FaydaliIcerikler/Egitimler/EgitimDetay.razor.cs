using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Egitim;
using VedasPortal.Entities.Models.PersonelDurumlari;
using VedasPortal.Repository.Interface;
using VedasPortal.Services.Pdf;

namespace VedasPortal.Pages.FaydaliIcerikler.Egitimler
{
    public partial class EgitimDetay
    {
        [Inject]
        private IBaseRepository<Egitim> EgitimServisi { get; set; }

        [Inject]
        public IBaseRepository<Dosya> DosyaServisi { get; set; }

        [Inject]
        private IBaseRepository<PersonelDurum> PersonelServisi { get; set; }

        [Inject]
        private IBaseRepository<UzmanlikAlani> Uzmanliklar { get; set; }

        public Dosya fileClass = new Dosya();
        public string pdfName = "";

        [Inject]
        private IFileService fileService { get; set; }

        [Inject]
        private IJSRuntime jSRuntime { get; set; }
      
        [Parameter]
        public int EgitimId { get; set; }

        [Parameter]
        public int PersonelId { get; set; }

        protected Egitim EgitimDetayGetir { get; set; }

        protected PersonelDurum PersonelDurum { get; set; }

        protected IEnumerable<UzmanlikAlani> UzmanlikAlani { get; set; }

        public void ShowOnCurrentPage(int fileId)
        {
            pdfName = string.Concat(fileClass.Files.SingleOrDefault(x => x.FileId == fileId)?.Adi, ".",
                fileClass.Files.SingleOrDefault(x => x.FileId == fileId)?.Uzanti);
        }

        public void ShowOnNewTab(int fileId)
        {
            pdfName = fileClass.Files.SingleOrDefault(x => x.FileId == fileId).Adi;
            jSRuntime.InvokeVoidAsync("OpenNewTab", pdfName);
        }

        protected IEnumerable<Dosya> Dosyalar { get; set; }

        protected IEnumerable<Dosya> TumDosyalariGetir()
        {
            Dosyalar = DosyaServisi.GetAll();
            return Dosyalar;

        }

        protected override Task OnInitializedAsync()
        {
            EgitimDetayGetir = EgitimServisi.Get(EgitimId);
            PersonelDurum = PersonelServisi.Get(PersonelId);
            TumDosyalariGetir();
            UzmanlikAlani = Uzmanliklar.GetAll();
            fileClass.Files = fileService.GetAllPDFs();
            return Task.CompletedTask;
        }

        [Inject]
        public IJSRuntime JsRun { get; set; }
        protected override async void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                await JsRun.InvokeVoidAsync("dataTables");
            }
        }
    }
}
