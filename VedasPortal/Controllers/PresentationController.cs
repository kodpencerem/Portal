using VedasPortal.Entities.Models.Dosya.FileManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Presentation;
using Syncfusion.PresentationToPdfConverter;
using System;
using System.Collections.Generic;
using System.IO;

namespace VedasPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresentationController : ControllerBase
    {
        private string basePath;
        private string baseLocation;
        private IWebHostEnvironment _hostingEnvironment;
        public PresentationController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            basePath = _hostingEnvironment.ContentRootPath;
            baseLocation = basePath + "\\wwwroot\\";
        }

        [Route("ConvertToPDF")]
        public string[] ConvertToPDF([FromBody] FileManagerDirectoryContent args)
        {
            string fileLocation = baseLocation + args.Path.Replace("/", "\\");
            //Belge zip dosyasından açılırsa, çıkarılan belge yolunu TargetPath özelliğinde koruduk.
            if (args.TargetPath != null)
                fileLocation = args.TargetPath;
            List<string> returnArray = new List<string>();
            using FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            //Mevcut sunuyu aç
            IPresentation presentation = Presentation.Open(fs);
            //PowerPoint belgesini PDF belgesine dönüştürün.
            PdfDocument pdfDocument = PresentationToPdfConverter.Convert(presentation);
            //Belgeyi bir akış olarak kaydedin ve akışı yeniden çalıştırın
            MemoryStream stream = new MemoryStream();
            //Oluşturulan PowerPoint belgesini MemoryStream'e kaydedin
            pdfDocument.Save(stream);
            stream.Position = 0;
            returnArray.Add("data:application/pdf;base64," + Convert.ToBase64String(stream.ToArray()));
            //Belge nesnelerini atın.
            presentation.Dispose();
            pdfDocument.Dispose();
            stream.Dispose();
            return returnArray.ToArray();

        }
    }
}