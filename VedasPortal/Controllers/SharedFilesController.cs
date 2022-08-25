using DocumentExplorer.Models.FileManager;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.Blazor.PdfViewer;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.Pdf;
using Syncfusion.Presentation;
using Syncfusion.PresentationRenderer;
using System.Drawing;
using System.IO;
using VedasPortal.Data;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class SharedFilesController : ControllerBase
    {
        private PhysicalFileProvider operation;
        private string basePath;
        public SharedFilesController(IWebHostEnvironment hostingEnvironment)
        {
            basePath = hostingEnvironment.ContentRootPath;
            operation = new PhysicalFileProvider();
            operation.RootFolder(basePath + "\\wwwroot\\SharedFiles"); // Data\\Dosyalar, hangi dosya ve klasörlerin mevcut olduğunu belirtir.
        }

        // Processing the File Manager operations
        [Route("FileOperations")]
        public object FileOperations([FromBody] FileManagerFilterContent args)
        {
            switch (args.Action)
            {
                // Özel işleminizi buraya ekleyin
                case "read":
                    // Path - Şuanki yol; ShowHiddenItems - Gizli öğeleri göstermek/gizlemek için Boole değeri
                    return operation.ToCamelCase(operation.GetFiles(args.Path, args.ShowHiddenItems));
                case "details":
                    // Path - Current path where details of file/folder is requested; Name - Names of the requested folders
                    return operation.ToCamelCase(operation.Details(args.Path, args.Names));
                case "create":
                    FileManagerResponse createresponse = new FileManagerResponse();
                    createresponse.Error = new ErrorDetails() { Code = "401", Message = "Restricted to perform this action" };
                    return operation.ToCamelCase(createresponse);
                case "search":
                    // Path - Aramanın yapıldığı mevcut yol; SearchString - Arama kutusuna yazılan dize; CaseSensitive - Aramanın büyük/küçük harf duyarlı olması gerekip gerekmediğini belirten Boole değeri
                    return operation.ToCamelCase(operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                case "delete":
                case "copy":
                case "move":
                case "rename":
                    FileManagerResponse renameresponse = new FileManagerResponse();
                    renameresponse.Error = new ErrorDetails() { Code = "401", Message = "Restricted to perform this action" };
                    return operation.ToCamelCase(renameresponse);
            }
            return null;
        }

        [Route("Download")]
        public IActionResult Download(string downloadInput)
        {

            FileManagerFilterContent args = JsonConvert.DeserializeObject<FileManagerFilterContent>(downloadInput);
            FileManagerDirectoryContent[] items = args.Data;
            string[] names = args.Names;
            for (var i = 0; i < items.Length; i++)
            {
                names[i] = (items[i].FilterPath + items[i].Name).Substring(1);
            }
            return operation.Download("/", names);
        }


        [Route("GetImage")]
        public IActionResult GetImage(FileManagerFilterContent args)
        {
            return operation.GetImage(args.Path, args.Id, false, null, null);
        }
        [Route("GetPreviewImage")]
        public IActionResult GetPreviewImage(FileManagerFilterContent args)
        {
            string baseFolder = basePath + "\\wwwroot\\SharedFiles";

            try
            {
                string fullPath = baseFolder + args.Path;
                string extension = Path.GetExtension(fullPath);
                Stream imageStream = null;
                if (extension == Constants.Pdf)
                {
                    FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                    PdfRenderer pdfExportImage = new PdfRenderer();
                    //Loads the PDF document 
                    pdfExportImage.Load(fileStream);
                    //Exports the PDF document pages into images
                    Bitmap[] bitmapimage = pdfExportImage.ExportAsImage(0, 0);
                    imageStream = new MemoryStream();
                    bitmapimage[0].Save(imageStream, System.Drawing.Imaging.ImageFormat.Png);
                    imageStream.Position = 0;
                    pdfExportImage.Dispose();
                    fileStream.Close();
                }
                else if (extension == Constants.Docx || extension == Constants.Rtf || extension == Constants.Doc)
                {
                    FileStream fileStream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                    //Dosya akışını Word belgesine yükler
                    WordDocument document = new WordDocument(fileStream, Syncfusion.DocIO.FormatType.Automatic);
                    fileStream.Dispose();
                    //Word'den PDF'ye dönüştürme için DocIORenderer örneği
                    DocIORenderer render = new DocIORenderer();
                    //Word belgesini PDF belgesine dönüştürür
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
                else if (extension == Constants.Pptx)
                {
                    IPresentation presentation = Presentation.Open(fullPath);
                    //Görüntü dönüştürme için PresentationRenderer'ı başlatın
                    presentation.PresentationRenderer = new PresentationRenderer();
                    //İlk slaydı resme dönüştür
                    imageStream = presentation.Slides[0].ConvertToImage(ExportImageFormat.Png);
                    presentation.Dispose();
                }
                FileStreamResult fileStreamResult = new FileStreamResult(imageStream, "APPLICATION/octet-stream");
                return fileStreamResult;
            }
            catch
            {
                return null;
            }
        }


        public class FileManagerFilterContent : FileManagerDirectoryContent
        {
            public string RootType { get; set; }
        }

    }
}