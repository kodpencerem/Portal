using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Services.FileUploadDownload
{
    // İndirme arayüzünün ne yapacağını tanımlayan arayüz
    public interface IFileDownload
    {
        // tüm dosyaları yükleme klasörümüze alma ve her biri için bir base64 url ​​döndürme yöntemi
        Task<List<string>> GetUploadedFiles();
        // sunucudan dosya indirme yöntemi
        Task DownloadFile(string url);
    }
    public class FileDownload : IFileDownload
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IJSRuntime _js;
        public FileDownload(IWebHostEnvironment webHostEnvironment, IJSRuntime js)
        {
            
            _webHostEnvironment = webHostEnvironment;
            // .NET'te js işlevlerinin yürütülmesini sağlayan javascript çalışma zamanı
            _js = js;
        }

        public async Task DownloadFile(string url)
        {
            // dosyayı indirmek için javascript yöntemini çağırın
            await _js.InvokeVoidAsync("downloadFile", url);
        }

        /// <summary>
        /// arayüzden GetUploadedFiles yönteminin uygulanması
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetUploadedFiles()
        {
            //sunucudan okunan dosyaların base64 url'lerini tutacak boş bir liste başlat
            var base64Urls = new List<string>();
            // Adını kullanarak dosya için yükleme yolu oluşturur
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "files");

            // Bu yükleme klasöründeki tüm dosyaları alın
            var files = Directory.GetFiles(uploadPath);

            // yükleme yolunun içinde bir dosya olduğunun kontrolü sağlanır
            if (files is not null && files.Length > 0)
            {
                // yükleme klasöründeki tüm dosyalar arasında dolaşın dosyayı okuyun ve base64 url'sini alın
                foreach (var filepath in files)
                {
                    // yüklemeler klasöründeki her dosyayı oku
                    using (var fileInput = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    {
                        // bir bellek akışı oluştur
                        var memorystream = new MemoryStream();
                        // dosyayı bir bellek akışına kopyalayın
                        await fileInput.CopyToAsync(memorystream);

                        // bellek akışımızı baytlara dönüştürür
                        var buffer = memorystream.ToArray();

                        // dosya uzantısı alır.
                        var fileType = GetMimeTypeForFileExtension(filepath);

                        // bayt dizisinden bir base64 url ​​dizesi oluşturup ve onu url listesine ekler
                        base64Urls.Add($"data:{fileType};base64,{Convert.ToBase64String(buffer)}");
                    }
                }
            }
            // base64 url'lerimizi döndür
            return base64Urls;
        }

        /// <summary>
        /// Dosya için MIME Türünü almak için yardımcı yöntem
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string GetMimeTypeForFileExtension(string filePath)
        {
            // varsayılan bir içerik türü tanımlar
            const string DefaultContentType = "application/octet-stream";

            var provider = new FileExtensionContentTypeProvider();
            // Dosya tipini ve geçerli yolu alır.
            if (!provider.TryGetContentType(filePath, out string contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
    }
}
