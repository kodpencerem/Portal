using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using VedasPortal.Models.YayinDurumlari;
using VedasPortal.Services.DuyuruHaber;

namespace VedasPortal.Pages.Duyurular.Admin
{
    public class DuyuruEkleDuzenleModel : ComponentBase
    {
        [Inject]
        protected DuyuruHaberService DuyuruHaberService { get; set; }
        [Inject]
        public NavigationManager UrlNavigationManager { get; set; }
        [Parameter]
        public int duyuruId { get; set; }

        protected DuyuruOlustur DuyuruModeli { get; set; } = new DuyuruOlustur();

        protected string ImageBase64String { get; set; }
        protected string PreviewImagePath { get; set; }

        protected EditContext EditContext { get; set; }

        protected string Title = "Ekle";
        public Yayin duyuru = new Yayin();

        protected override async Task OnParametersSetAsync()
        {
            if (duyuruId != 0)
            {
                Title = "Duzenle";
                duyuru = await DuyuruHaberService.DetayGetir(duyuruId);
            }
        }

        protected async Task DuyuruKayit()
        {
            if (duyuru.Id != 0)
            {
                duyuru = new Yayin()
                {
                    Id = DuyuruModeli.Id,
                    Adi = DuyuruModeli.DuyuruAdi,
                    DosyaYolu = PreviewImagePath
                };

                await DuyuruHaberService.Duzenle(duyuru);
            }
            else
            {

                duyuru = new Yayin()
                {
                    Id = DuyuruModeli.Id,
                    Adi = DuyuruModeli.DuyuruAdi,
                    DosyaYolu = PreviewImagePath
                };
                await DuyuruHaberService.Ekle(duyuru);

            }

            Cancel();
        }

        public void Cancel()
        {
            UrlNavigationManager.NavigateTo("/duyurulistele");
        }

        protected override void OnInitialized()
        {
            EditContext = new EditContext(DuyuruModeli);
            EditContext.AddDataAnnotationsValidation();
        }

        protected async Task HandleInputFileChange(InputFileChangeEventArgs e)
        {
            await UpdatePreviewASync(e.File);
            DuyuruModeli.DuyuruResmi = e.File;
            EditContext.Validate();
        }

        protected async Task UpdatePreviewASync(IBrowserFile browserFile)
        {
            Stream inputFileStream = browserFile.OpenReadStream();
            using MemoryStream memoryStream = new MemoryStream();
            await inputFileStream.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();
            ImageBase64String = Convert.ToBase64String(imageBytes);
            PreviewImagePath = $"data:image/png;base64,{ImageBase64String}";
        }

        protected int Width { get; set; }

        protected int Height { get; set; }

        protected async Task ResizeImageAsync()
        {
            if (Width > 0 && Height > 0)
            {
                IBrowserFile image = DuyuruModeli.DuyuruResmi;
                if (image != null)
                {
                    image = await image.RequestImageFileAsync("image/jpg", Width, Height);
                    await UpdatePreviewASync(image);
                }
            }
        }

        protected class DuyuruOlustur
        {
            public int Id { get; set; }
            [Required]
            public string DuyuruAdi { get; set; }

            [Required]
            public string DuyuruAciklama { get; set; }

            [Required]
            public IBrowserFile DuyuruResmi { get; set; }
        }
    }
}
