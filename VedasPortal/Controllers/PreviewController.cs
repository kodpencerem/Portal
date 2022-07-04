using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor.PdfViewer;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.Presentation;
using Syncfusion.PresentationRenderer;
using System;
using System.Drawing;
using System.IO;
using VedasPortal.Data;
using VedasPortal.Entities.Models.Dosya;
using VedasPortal.Entities.Models.Dosya.FileManager;
using DocIO = Syncfusion.DocIO.DLS;

namespace VedasPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private PhysicalFileProvider operation;
        private string basePath;
        public PreviewController(IWebHostEnvironment hostingEnvironment)
        {
            basePath = hostingEnvironment.ContentRootPath;
            operation = new PhysicalFileProvider();
            operation.RootFolder(basePath + "\\wwwroot\\Files"); // Data\\Dosyalar, hangi dosya ve klasörlerin mevcut olduğunu belirtir.
        }

        [Route("GetPreview")]
        public string GetPreview([FromBody] FileManagerDirectoryContent args)
        {
            string baseFolder = basePath + "\\wwwroot\\Files";
            try
            {
                string fullPath = baseFolder + args.Path;
                string extension = Path.GetExtension(fullPath);
                Stream imageStream = null;
                if (extension == Constants.Pdf)
                {
                    try
                    {
                        FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                        PdfRenderer pdfExportImage = new PdfRenderer();
                        //PDF belgesini yükler
                        pdfExportImage.Load(fileStream);
                        //PDF belge sayfalarını görüntülere aktarır
                        Bitmap[] bitmapimage = pdfExportImage.ExportAsImage(0, 0);
                        imageStream = new MemoryStream();
                        bitmapimage[0].Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                        imageStream.Position = 0;
                        pdfExportImage.Dispose();
                        fileStream.Close();
                    }
                    catch
                    {
                        imageStream = null;
                    }
                }
                else if (extension == Constants.Docx || extension == Constants.Rtf || extension == Constants.Doc || extension == Constants.Txt)
                {
                    try
                    {
                        FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                        //Dosya akışını Word belgesine yükler
                        DocIO.WordDocument document = new DocIO.WordDocument(fileStream, GetDocIOFormatType(extension));
                        fileStream.Dispose();
                        //Word'den PDF'ye dönüştürme için DocIORenderer örneği
                        DocIORenderer render = new DocIORenderer();
                        // Word belgesini PDF belgesine dönüştürür
                        PdfDocument pdfDocument = render.ConvertToPDF(document);
                        //Word belgesi ve DocIO Renderer nesneleri tarafından kullanılan tüm kaynakları serbest bırakır
                        render.Dispose();
                        document.Dispose();
                        //PDF dosyasını kaydeder
                        MemoryStream outputStream = new MemoryStream();
                        pdfDocument.Save(outputStream);
                        outputStream.Position = 0;
                        //PDF belge nesnesinin örneğini kapatır
                        pdfDocument.Close();

                        PdfRenderer pdfExportImage = new PdfRenderer();
                        //PDF belgesini yükler
                        pdfExportImage.Load(outputStream);
                        //PDF belge sayfalarını görüntülere aktarır
                        Bitmap[] bitmapimage = pdfExportImage.ExportAsImage(0, 0);
                        imageStream = new MemoryStream();
                        bitmapimage[0].Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                        imageStream.Position = 0;

                        fileStream.Close();
                    }
                    catch
                    {
                        imageStream = null;
                    }
                }
                else if (extension == Constants.Pptx)
                {
                    try
                    {
                        IPresentation presentation = Presentation.Open(fullPath);
                        //Görüntü dönüştürme için PresentationRenderer'ı başlatın
                        presentation.PresentationRenderer = new PresentationRenderer();
                        //İlk slaydı resme dönüştür
                        imageStream = presentation.Slides[0].ConvertToImage(ExportImageFormat.Png);
                        presentation.Dispose();
                    }
                    catch
                    {
                        imageStream = null;
                    }
                }
                if (imageStream != null)
                {
                    byte[] bytes = new byte[imageStream.Length];
                    imageStream.Read(bytes);
                    string base64 = Convert.ToBase64String(bytes);
                    return "data:image/png;base64, " + base64;
                }
                else
                {
                    return "Error";
                }
            }
            catch
            {
                return "Error";
            }
        }

        private Syncfusion.DocIO.FormatType GetDocIOFormatType(string format)
        {
            if (string.IsNullOrEmpty(format))
                throw new NotSupportedException("DocumentEditor bu dosya biçimini desteklemiyor.");
            switch (format.ToLower())
            {
                case Constants.Dotx:
                case Constants.Docx:
                case Constants.Docm:
                case Constants.Dotm:
                    return Syncfusion.DocIO.FormatType.Docx;
                case Constants.Dot:
                case Constants.Doc:
                    return Syncfusion.DocIO.FormatType.Doc;
                case Constants.Rtf:
                    return Syncfusion.DocIO.FormatType.Rtf;
                case Constants.Txt:
                    return Syncfusion.DocIO.FormatType.Txt;
                case Constants.Xml:
                    return Syncfusion.DocIO.FormatType.WordML;
                case Constants.Html:
                    return Syncfusion.DocIO.FormatType.Html;
                default:
                    throw new NotSupportedException("DocumentEditor bu dosya biçimini desteklemiyor.");
            }
        }
    }
}
