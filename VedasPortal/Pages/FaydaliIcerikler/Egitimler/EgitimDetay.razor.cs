using BlazorInputFile;
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
        private IFileService fileService { get; set; }

        [Inject]
        private IJSRuntime jSRuntime { get; set; }

        [Inject]
        private IPdfUpload fileUpload { get; set; }

        [Inject]
        private IBaseRepository<PersonelDurum> PersonelServisi { get; set; }

        [Inject]
        private IBaseRepository<UzmanlikAlani> Uzmanliklar { get; set; }

        [Parameter]
        public int EgitimId { get; set; }

        [Parameter]
        public int PersonelId { get; set; }

        protected Egitim EgitimDetayGetir { get; set; }

        protected PersonelDurum PersonelDurum { get; set; }

        protected IEnumerable<UzmanlikAlani> UzmanlikAlani { get; set; }

        public FileClass fileClass = new FileClass();
        List<IFileListEntry> files = new List<IFileListEntry>();
        public string pdfName = "";

        public async Task HandleFileSelected(IFileListEntry[] entryFiles)
        {
            files = new List<IFileListEntry>();
            foreach (var file in entryFiles)
            {
                if (file != null)
                {
                    await fileUpload.Upload(file);
                    files.Add(file);
                }
            }
            fileClass.Files = fileService.GetAllPDFs();
        }

        public void ShowOnCurrentPage(int fileId)
        {
            pdfName = fileClass.Files.SingleOrDefault(x => x.FileId == fileId).Name;
        }

        public void ShowOnNewTab(int fileId)
        {
            pdfName = fileClass.Files.SingleOrDefault(x => x.FileId == fileId).Name;
            jSRuntime.InvokeVoidAsync("OpenNewTab", pdfName);
        }

        protected override Task OnInitializedAsync()
        {
            EgitimDetayGetir = EgitimServisi.Get(EgitimId);
            PersonelDurum = PersonelServisi.Get(PersonelId);
            UzmanlikAlani = Uzmanliklar.GetAll();
            fileClass.Files = fileService.GetAllPDFs();
            return Task.CompletedTask;
        }
    }
}
