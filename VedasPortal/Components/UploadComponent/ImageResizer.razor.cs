﻿using Blazor.Cropper;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VedasPortal.Components.ModalComponents;
using VedasPortal.Models.Dosya;


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
        /// Kullanıcıya bir mesaj döndürür
        /// </summary>
        private readonly string prompt = "Resim Başarıyla Kırpıldı...";

        /// <summary>
        /// Nesneyi ayrıştırma işlemlerini bool döndürür
        /// </summary>
        private bool parsing = false;

        /// <summary>
        /// Resim kırpmak ve ayrıştırmak için bir ekran açar
        /// </summary>
        private bool ShowCroper { get; set; } = false;


        [Parameter]
        public Dosya Value { get; set; }

        [Parameter]
        public EventCallback<Dosya> ValueChanged { get; set; }

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

        void OpenModal()
        {
            isOpened = true;
        }

        /// <summary>
        /// Resim kırpma ekranını bir popup olarak açılmasını sağlar
        /// </summary>
        public ShowModalComponent ModalShow { get; set; }

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

        // yalnızca yükleme sırasında ilerlemenin görüntülenmesini değiştirmek için kullanılır
        private bool displayProgress;
        // ilerlemeyi yüzde olarak yüklemek için
        private int progressPercent;
        // Yüklemenin sonuçlarını göstermek için bir yazı gösterir
        private string labelText = "";

        // yüklenecek seçili dosyaların listesi
        IReadOnlyList<IBrowserFile> selectedFiles;
        // dosyalar için önizleme URL'lerinin listesi
        private IList<string> previewImages = new List<string>();

        /// <summary>
        /// Ön yüklemeden gelebilecek değişiklikleri algılar. Seçilen dosyayı kırpma işlemi bir popup açar ve kırpma işlemlerini aktif eder.
        /// </summary>
        /// <param name="args"></param>
        protected async void OnInputFileChange(InputFileChangeEventArgs args)
        {

            // Dosya seçicide seçilen tüm dosyaları al
            var files = e.GetMultipleFiles();
            selectedFiles = files;
            foreach (var file in files)
            {
                // resim dosyası için önizleme url'si oluştur
                var imageUrl = await fileUpload.GeneratePreviewUrl(file);

                // resim url'sini önizleme url listesine ekler
                previewImages.Add(imageUrl);

            }

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
            StateHasChanged();
            await Task.Delay(10);
            await JSRuntime.InvokeVoidAsync("console.log", "converted!");
#pragma warning disable CS0618 // Type or member is obsolete
            string base64String = await args.GetBase64Async();
#pragma warning restore CS0618 // Type or member is obsolete
            var fileName = SaveFileToUploaded.RandomFileName + browserFileResizer.Name;
            File.WriteAllBytes(Path.Combine(SaveFileToUploaded.ImageUploadedPath, fileName), Convert.FromBase64String(base64String));
            PreviewImagePath = $"data:image/png;base64,{base64String}";
            args.Dispose();
            parsing = false;
            var newFile = new Dosya
            {
                Adi = fileName,
                Boyutu = browserFileResizer.Size.ToString(),
                Uzanti = fileName.Substring('.')
            };
            Value = newFile;
            await ValueChanged.InvokeAsync(Value);

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

        }

        private readonly int MaxAllowedFileSize = 10 * 1024 * 1024;

        /// <summary>
        /// Resim üzerinden gerçekleşen güncellemeleri tutar.
        /// </summary>
        /// <param name="browserFile"></param>
        /// <returns></returns>
        private async Task UpdatePreviewASync(IBrowserFile browserFile)
        {
            Stream inputFileStream = browserFile.OpenReadStream(MaxAllowedFileSize);
            using MemoryStream memoryStream = new MemoryStream();
            await inputFileStream.CopyToAsync(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();
            ImageBase64String = Convert.ToBase64String(imageBytes);
            PreviewImagePath = $"data:image/png;base64,{ImageBase64String}";
        }
    }
}
