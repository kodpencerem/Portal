using Blazor.Cropper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading.Tasks;
using VedasPortal.Components.ShowModalComponent;

namespace VedasPortal.Components.UploadComponent
{
    public partial class ImageResizer
    {
        /// <summary>
        /// Cropper kütüphaneden bir nesne örneği oluşturur. Resim kırpma ve boyutlandırma özelliklerine erişim verir.
        /// </summary>
        protected Cropper cropper;

        /// <summary>
        /// Dosya seçilmesi için bir pencere açar
        /// </summary>
        protected IBrowserFile browserFileResizer;

        /// <summary>
        /// Resim öngörünümü için bir yol belirler
        /// </summary>
        private string PreviewImagePath { get; set; }

        /// <summary>
        /// Base64 string tipinde bir değişkendir
        /// </summary>
        private string ImageBase64String { get; set; }

        /// <summary>
        /// Nesneyi ayrıştırma işlemlerini döndürür
        /// </summary>
        private bool parsing = false;

        /// <summary>
        /// Resim kırpmak ve ayrıştırmak için bir ekran açar
        /// </summary>
        private bool ShowCroper { get; set; } = false;

        private string _value;

        [Parameter] public EventCallback<string> ValueInputChanged { get; set; }

        [Parameter]
        public string ValueInput
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                ValueInputChanged.InvokeAsync(value);
            }
        }

        /// <summary>
        /// Resmin üzerinde kırpma ve boyutlandırma işlemleri için bir araç açar
        /// </summary>
        private bool IsAspectRatioEnabled { get; set; }

        /// <summary>
        /// Resmin yükseklik ve genişlik değerlerini ayarlar.
        /// </summary>
        private double AspectRatio { get; set; } = 1d;

        /// <summary>
        /// ShowCroper ekranının açılması işlevini görür
        /// </summary>
        bool isOpened = false;

        /// <summary>
        /// Bir popup açar ve modeli gösterir
        /// </summary>
        void OpenModal()
        {
            isOpened = true;
        }

        /// <summary>
        /// Resim kırpma ekranını bir popup olarak açılmasını sağlar
        /// </summary>
        public ShowModal ModalShow { get; set; }

        /// <summary>
        /// Resmin ön yüzü üzerinde resmini kolayca kırpılmasını sağlayan bir pencere açar
        /// </summary>
        public double ratio { get; set; } = 1;

        /// <summary>
        /// Ratio'dan seçilen genişlik değerini tutar
        /// </summary>
        private double AspectWidth { get; set; } = 1;

        /// <summary>
        /// Resim kırpma sonrası genişlik değerini okur
        /// </summary>
        /// <param name="eventArgs"></param>
        private void OnAspectWidthChanged(ChangeEventArgs eventArgs)
        {
            AspectWidth = double.Parse((string)eventArgs.Value);
            AspectRatio = AspectHeight / AspectWidth;
        }

        private double AspectHeight { get; set; } = 1;

        /// <summary>
        /// Resim kırpma sonrası yükseklik değerini okur
        /// </summary>
        /// <param name="eventArgs"></param>
        private void OnAspectHeightChanged(ChangeEventArgs eventArgs)
        {
            AspectHeight = double.Parse((string)eventArgs.Value);
            AspectRatio = AspectHeight / AspectWidth;
        }

        /// <summary>
        /// Resim kırpma değerlerini -String gelecek değerleri - integer türünde tutar
        /// </summary>
        /// <param name="args"></param>
        private void OnRatioChange(ChangeEventArgs args)
        {
            ratio = int.Parse(args.Value.ToString()) / 100.0;
        }

        //IList<Dosya> imageDataUrls = new List<Dosya>();
        /// <summary>
        /// Ön yüklemeden gelebilecek değişiklikleri algılar. Seçilen dosyayı kırpma işlemi bir popup açar ve kırpma işlemlerini aktif eder.
        /// </summary>
        /// <param name="args"></param>
        protected Task OnInputFileChange(InputFileChangeEventArgs args)
        {
            foreach (var imageFile in args.GetMultipleFiles())
            {
                PreviewImagePath = null;
                browserFileResizer = imageFile;
                ShowCroper = true;
            }
            return Task.CompletedTask;
        }

        private double CropCurrentWidth { get; set; }
        private double CropCurrentHeight { get; set; }

        /// <summary>
        /// Resim boyutunda olabilecek genişlik ve yükseklik değerlerini tutar
        /// </summary>
        /// <param name="cropSize">Kırpma boyutu</param>
        private void HandleCropSizeChanged((double, double) cropSize)
        {
            CropCurrentWidth = cropSize.Item1;
            CropCurrentHeight = cropSize.Item2;
        }

        /// <summary>
        /// Kırpma işlemlerini yapar ve resmin son değişiklerini ilgili dosya yoluna kaydeder
        /// </summary>
        /// <returns></returns>
        protected async Task DoneCrop()
        {
            
            ImageCroppedResult args = await cropper.GetCropedResult();
            ShowCroper = false;
            parsing = true;

            var fileName = SaveFileToUploaded.RandomFileName + browserFileResizer.Name;
            SaveFileToUploaded.FileName = fileName;
            StateHasChanged();
            await Task.Delay(10);
            await JSRuntime.InvokeVoidAsync("console.log", "Dönüştürüldü!");
            string base64String = await args.GetBase64Async();
            File.WriteAllBytes(
                Path.Combine(
                    SaveFileToUploaded.ImageUploadedPath, fileName),
                Convert.FromBase64String(base64String));
            PreviewImagePath = $"data:image/png;base64,{base64String}";
            args.Dispose();
            parsing = false;
            ValueInput = fileName;
            await ValueInputChanged.InvokeAsync(ValueInput);
        }

        /// <summary>
        /// Resim kırpma işleminden vazgeçilmesi halinde çalışan metottur
        /// </summary>
        /// <returns></returns>
        private async Task CancelCropAsync()
        {
            ShowCroper = false;
            await UpdatePreviewASync(browserFileResizer);
            PreviewImagePath = null;
            isOpened = false;
        }

        private readonly int MaxAllowedFileSize = 10 * 1024 * 1024;
        /// <summary>
        /// Resim üzerinden gerçekleşen güncellemeleri tutar.
        /// </summary>
        /// <param name="browserFile"></param>
        /// <returns></returns>
        private async Task UpdatePreviewASync(IBrowserFile browserFile)
        {
            if (browserFile != null)
            {
                Stream inputFileStream = browserFile.OpenReadStream(MaxAllowedFileSize);
                using MemoryStream memoryStream = new();
                await inputFileStream?.CopyToAsync(memoryStream);
                byte[] imageBytes = memoryStream.ToArray();
                ImageBase64String = Convert.ToBase64String(imageBytes);
                PreviewImagePath = $"data:image/png;base64,{ImageBase64String}";
            }
        }
    }
}
