using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;

namespace VedasPortal.Services.Pdf
{
    public class PdfUpload : IPdfUpload
    {
        IHostingEnvironment _hostingEnvironment = null;
        public PdfUpload(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task Upload(IFileListEntry file)
        {
            var fileName = SaveFileToUploaded.RandomFileName + file.Name;
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "files", fileName);
            var memoryStream = new MemoryStream();

            await file.Data.CopyToAsync(memoryStream);

            using(FileStream fileStream = new FileStream(path,FileMode.Create, FileAccess.Write))
            {
                memoryStream.WriteTo(fileStream);
            }
        }
    }
}
