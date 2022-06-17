using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Services.Pdf
{
    public class FileService : IFileService
    {

        IWebHostEnvironment _hostingEnvironment = null;
        public FileService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public List<Dosya> GetAllPDFs()
        {
            List<Dosya> files = new();
            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";

            int nFileId = 1;

            foreach(string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                files.Add(new Dosya
                {
                    FileId = nFileId++,
                    Adi = Path.GetFileName(pdfPath),
                    Yolu = pdfPath,
                });
            }
            return files;
        }
    }
}
