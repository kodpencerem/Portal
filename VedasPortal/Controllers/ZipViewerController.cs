using DocumentExplorer.Data;
using DocumentExplorer.Models.FileManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;

namespace VedasPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipViewerController : ControllerBase
    {
        private PhysicalFileProvider operation;        
        private string tempDir;
        private string basePath;
        private string baseLocation;
        private IWebHostEnvironment _hostingEnvironment;


        public ZipViewerController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            this.basePath = _hostingEnvironment.ContentRootPath;
            this.baseLocation = this.basePath + "\\wwwroot\\";
            // Zip dosyas�n�n i�eri�ini depolamak i�in ge�ici konum
            // this.tempDir = this.basePath + "\\" + "tempZipStorage";
            this.tempDir = Path.GetTempPath() + "tempZipStorage";
            if (!Directory.Exists(this.tempDir))
                Directory.CreateDirectory(this.tempDir);
            this.operation = new PhysicalFileProvider();
            //this.operation.RootFolder(this.basePath + "\\wwwroot\\Files"); // Data\\Dosyalar, hangi dosya ve klas�rlerin mevcut oldu�unu belirtir.
            this.operation.RootFolder(this.tempDir);
        }

        [Route("Root")]
        public string Root()
        {
            return this.tempDir;
        }

        // Dosya Y�neticisi i�lemlerini i�leme
        [Route("FileOperations")]
        public object FileOperations([FromBody] ReadArgs args)
        {
            try
            {
                switch (args.Action)
                {
                    // �zel i�lemler bu k�sma eklenir
                    case "read":
                        // Path - �uanki yol; ShowHiddenItems - Gizli ��eleri g�stermek/gizlemek i�in Boole de�eri
                        return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                    case "search":
                    case "details":
                    case "delete":
                    case "copy":
                    case "move":
                    case "create":
                    case "rename":
                        FileManagerResponse response = new FileManagerResponse();
                        response.Error = new ErrorDetails() { Code = "401", Message = "Bu eylemi ger�ekle�tirmek i�in Zip dosyas�n� ��kar�n" };
                        return this.operation.ToCamelCase(response);
                }
                return null;
            }
            catch (IOException e)
            {
                throw e;
            }
        }
        [Route("ExtractZip")]
        public IActionResult ExtractZip([FromBody] FileManagerDirectoryContent args)
        {
            DeleteDirectoryContent();
            string zipLocation = this.baseLocation + args.Path;
            ZipFile.ExtractToDirectory(zipLocation, this.tempDir);
            return Content("Extracted");
        }

        public string Extract(string ZipPath)
        {
            try
            {
                DeleteDirectoryContent();
                string zipLocation = this.baseLocation + ZipPath;
                if (System.IO.File.Exists(zipLocation))
                {
                    ZipFile.ExtractToDirectory(zipLocation, this.tempDir);
                    return "Extracted";
                }
                else
                {
                    return "PathNotFound";
                }
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public void DeleteDirectoryContent()
        {
            string path = tempDir;
            try
            {
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);
                foreach (string file in files)
                {
                    System.IO.File.SetAttributes(file, FileAttributes.Normal);
                    System.IO.File.Delete(file);
                }
                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir);
                }
            }
            catch (IOException e)
            {
                throw e;
            }
        }
        public void DeleteDirectory(string path)
        {

            try
            {
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);
                foreach (string file in files)
                {
                    System.IO.File.SetAttributes(file, FileAttributes.Normal);
                    System.IO.File.Delete(file);
                }
                foreach (string dir in dirs)
                {
                    DeleteDirectory(dir);
                }
                Directory.Delete(path, true);
            }
            catch (IOException e)
            {
                throw e;
            }
        }
    }
    public class ReadArgs : FileManagerDirectoryContent
    {
        public string ZipPath { get; set; }
    }
}