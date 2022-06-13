using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Services.Pdf
{
    public class FileService : IFileService
    {

        IHostingEnvironment _hostingEnvironment = null;
        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public List<FileClass> GetAllPDFs()
        {
            List<FileClass> files = new List<FileClass>();
            string path = $"{_hostingEnvironment.WebRootPath}\\files\\";

            int nFileId = 1;

            foreach(string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
            {
                files.Add(new FileClass
                {
                    FileId = nFileId++,
                    Name = Path.GetFileName(pdfPath),
                    Path = pdfPath

                });
            }
            return files;
        }
    }
}
