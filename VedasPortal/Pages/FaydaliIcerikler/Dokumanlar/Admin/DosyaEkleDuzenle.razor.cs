using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Enums;
using VedasPortal.Repository.Interface;
using VedasPortal.Services.Pdf;

namespace VedasPortal.Pages.FaydaliIcerikler.Dokumanlar.Admin
{
    public class DosyaModel : ComponentBase
    {

        [Inject]
        public IBaseRepository<Dosya> DosyaServisi { get; set; }

        [Parameter]
        public int DosyaId { get; set; }

        protected string Title = "Ekle";
        public Dosya dokuman = new();

        protected IEnumerable<Dosya> Dosyalar { get; set; }

        protected IEnumerable<Dosya> TumDosyalariGetir()
        {
            Dosyalar = DosyaServisi.GetAll();
            return Dosyalar;

        }
        public Dictionary<DosyaKategori, string> Kategoriler { get; set; }
        protected void TumKategorileriGetir()
        {
            var list = new Dictionary<DosyaKategori, string>();
            foreach (DosyaKategori item in Enum.GetValues(typeof(DosyaKategori)))
            {
                list.Add(item, item.TextDosya());
            }
            Kategoriler = list;
        }
        [CascadingParameter]
        public Task<AuthenticationState> State { get; set; }
        protected async Task KayitAsync()
        {
            var authState = await State;
            var fileName = SaveFileToUploaded.FileName.Split(".");
            var filePath = SaveFileToUploaded.FileUploadedPath;
            var dosya = new Dosya()
            {
                Adi = fileName[0],
                Yolu = filePath,
                Uzanti = fileName[1],
                Kategori = dokuman.Kategori,
                Aciklama = dokuman.Aciklama,
                AltBaslik = dokuman.AltBaslik,
                Birimler = dokuman.Birimler,
                Boyutu = dokuman.Boyutu,
                KayitTarihi = dokuman.KayitTarihi,
                AktifPasif = true,
                KaydedenKullanici = authState.User.Identity.Name,
            };
            DosyaServisi.Add(dosya);
            TumDosyalariGetir();
            dokuman = new Dosya();
        }
        protected override void OnParametersSet()
        {
            if (DosyaId != 0)
            {
                Title = "Duzenle";
                dokuman = DosyaServisi.Get(DosyaId);
            }
        }
        protected void SilmeyiOnayla(int dosyaId)
        {
            ModalDialog.Open();
            dokuman = Dosyalar.FirstOrDefault(x => x.Id == dosyaId);
        }
        public ModalComponent ModalDialog { get; set; }
        protected string DialogGorunur { get; set; } = "none";

        protected void Sil()
        {
            if (dokuman.Id == 0)
                return;

            DosyaServisi.Remove(dokuman.Id);
            dokuman = new Dosya();
            TumDosyalariGetir();
        }

        public Dosya fileClass = new Dosya();
        public string pdfName = "";

        [Inject]
        private IFileService fileService { get; set; }

        public void ShowOnCurrentPage(int fileId)
        {
            pdfName = string.Concat(fileClass.Files.SingleOrDefault(x => x.FileId == fileId)?.Adi, ".",
                fileClass.Files.SingleOrDefault(x => x.FileId == fileId)?.Uzanti);
        }
        protected override Task OnInitializedAsync()
        {
            fileClass.Files = fileService.GetAllPDFs();
            TumDosyalariGetir();
            TumKategorileriGetir();
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
