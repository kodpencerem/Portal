using Blazor.Cropper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;

namespace VedasPortal.Components.UploadComponent
{
    public partial class ImageResizer
    {
        private Cropper cropper;

        private IBrowserFile browserFileResizer;
        private string PreviewImagePath { get; set; }
        private string ImageBase64String { get; set; }

        private readonly string prompt = "Resim Başarıyla Kırpıldı...";
        private bool parsing = false;

        private bool ShowCroper { get; set; } = false;

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public EventCallback<ChangeEventArgs> ValueChanged { get; set; }

        private bool IsAspectRatioEnabled { get; set; }

        private double AspectRatio { get; set; } = 1d;

        public double ratio { get; set; } = 1;

        private double AspectWidth { get; set; } = 1;

       
     
      
        private void OnAspectWidthChanged(ChangeEventArgs eventArgs)
        {
            AspectWidth = double.Parse((string)eventArgs.Value);

            AspectRatio = AspectHeight / AspectWidth;
        }

        private double AspectHeight { get; set; } = 1;

        private void OnAspectHeightChanged(ChangeEventArgs eventArgs)
        {
            AspectHeight = double.Parse((string)eventArgs.Value);

            AspectRatio = AspectHeight / AspectWidth;
        }

        private void OnRatioChange(ChangeEventArgs args)
        {
            ratio = int.Parse(args.Value.ToString()) / 100.0;
        }

        private void OnInputFileChange(InputFileChangeEventArgs args)
        {
            PreviewImagePath = null;
            browserFileResizer = args.File;
            ShowCroper = true;
            
        }
        private double CropCurrentWidth { get; set; }
        private double CropCurrentHeight { get; set; }
        private void HandleCropSizeChanged((double, double) cropSize)
        {
            CropCurrentWidth = cropSize.Item1;
            CropCurrentHeight = cropSize.Item2;
        }

        private async Task DoneCrop()
        {
            ImageCroppedResult args = await cropper.GetCropedResult();
            ShowCroper = false;
            parsing = true;
            StateHasChanged();
            await Task.Delay(10);
            await JSRuntime.InvokeVoidAsync("console.log", "converted!");



            string base64String = await args.GetBase64Async();
            var fileName= SaveFileToUploaded.RandomFileName+ browserFileResizer.Name;
            File.WriteAllBytes(Path.Combine(SaveFileToUploaded.ImageUploadedPath,fileName), Convert.FromBase64String(base64String));
            
            PreviewImagePath = $"data:image/png;base64,{base64String}";
            args.Dispose();
            parsing = false;
        }

        private async Task CancelCropAsync()
        {
            ShowCroper = false;
            await UpdatePreviewASync(browserFileResizer);
        }

        private readonly int MaxAllowedFileSize = 10 * 1024 * 1024;

        private async Task UpdatePreviewASync(IBrowserFile browserFile)
        {
            Stream inputFileStream = browserFile.OpenReadStream(MaxAllowedFileSize);
            using MemoryStream memoryStream = new MemoryStream();
            await inputFileStream.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();
            ImageBase64String = Convert.ToBase64String(imageBytes);
            PreviewImagePath = $"data:image/png;base64,{ImageBase64String}";
        }


        //[Inject]
        //public IBaseRepository<DosyaYukle> DosyaServisi { get; set; }

        //DosyaYukle dosyaYukle = new DosyaYukle();

        //public byte[] ImageUpladed { get; set; }

        //void ValidSubmit()
        //{
        //    dosyaYukle.Id = 0;
        //    dosyaYukle.DosyaBoyutu = ImageUpladed;
        //    DosyaServisi.UploadImage(dosyaYukle);
        //}

        //async Task HandleFileSelected(IFileListEntry[] files)
        //{
        //    var file = files.FirstOrDefault();
        //    if (file != null)
        //    {

        //        var ms = new MemoryStream();
        //        await file.Data.CopyToAsync(ms);
        //        ImageUpladed = ms.ToArray();
        //    }
        //}
    }
}
