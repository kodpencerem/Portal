using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace VedasPortal.Services.FileUploadDownload
{
    public interface IFileUpload
    {
        /// <summary>
        /// dosya yükleme yöntemi
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<string> UploadFile(IBrowserFile file);
        /// <summary>
        /// önizleme url'si oluşturma yöntemi
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        Task<string> GeneratePreviewUrl(IBrowserFile file);

        bool DeleteFile(string fileName);
    }

    public class FileUpload : IFileUpload
    {

        private IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileUpload> _logger;

        /// <summary>
        /// web barındırma ortamı, uygulamanın benzer dosya konumunda çalıştığı ortam hakkında bilgi içerir
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        /// <param name="logger"></param>
        public FileUpload(IWebHostEnvironment webHostEnvironment, ILogger<FileUpload> logger)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Diğer dosya türleri için yalnızca görüntüleri önizleyebiliriz, görseller klasöründe içerik türü logo olan görselleri kullanabiliriz 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task<string> GeneratePreviewUrl(IBrowserFile file)
        {
            
            if (!file.ContentType.Contains("image"))
            {
                // Örneğin, pdf için önizlemede bir pdf dosyasının logosunu kullanacağız.
                if (file.ContentType.Contains("pdf"))
                {
                    return "img/pdf_logo.png";
                }
            }

            // resmi önizlemede yeniden boyutlandır
            var resizedImage = await file.RequestImageFileAsync(file.ContentType, 100, 100);

            // arabellek boyutunu yeniden boyutlandırılımış görüntü boyutuna ayarlar
            var buffer = new byte[resizedImage.Size];

            // boyutlandırılmış dosyayı oku
            await resizedImage.OpenReadStream().ReadAsync(buffer);

            // url oluşturup, önizleme listesine ekleme yapar
            return $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";
        }

        public async Task UploadFile(IBrowserFile file)
        {
            // dosya geçerli ise 
            if (file is not null)
            {
                try
                {
                    var fileName = SaveFileToUploaded.RandomFileName + file.Name;
                    // Bir dosya yolu oluşturup kendi ismi ile kaydet
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "images/uploaded", fileName);
                    // dosyayı yüklemek için akış açar ve dosya yükleme gerçekleştirir
                    using (var stream = file.OpenReadStream())
                    {
                        // yükleme yoluna yazma erişimi oluşturur.
                        var fileStream = File.Create(uploadPath);
                        // erişim olan yola kopyalama gerçekleştirir
                        await stream.CopyToAsync(fileStream);
                        // akışı kapatıp kaynakları serbest bırakır
                        fileStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Özel durumları günlüğe kaydeder. Ve hata durumlarını işler
                    _logger.LogError(ex.ToString());
                }

            }

        }

        Task<string> IFileUpload.UploadFile(IBrowserFile file)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFile(string fileName)
        {
            try
            {
                var path = $"{_webHostEnvironment.WebRootPath}\\images\\uploaded\\{fileName}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
