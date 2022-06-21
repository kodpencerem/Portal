using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SfFileService.FileManager.Base;
using SfFileService.FileManager.PhysicalFileProvider;
using System;
using System.Collections.Generic;

namespace VedasPortal.Controllers
{

    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class FileManagerController : Controller
    {
        public PhysicalFileProvider operation;
        public string basePath;
        string root = "wwwroot\\files";
        public FileManagerController(IWebHostEnvironment hostingEnvironment)
        {
            basePath = hostingEnvironment.ContentRootPath;
            operation = new PhysicalFileProvider();
            if (basePath.EndsWith("\\"))
                operation.RootFolder(basePath + root);
            else
                operation.RootFolder(basePath + "\\" + root);
        }
        [Route("FileOperations")]
        public object FileOperations([FromBody] FileManagerDirectoryContent args)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin,VideoEkleDuzenle,DosyaEkleDuzenle"))
            {
                if (args.Action == "delete" || args.Action == "rename")
                {
                    if (args.TargetPath == null && args.Path == "")
                    {
                        FileManagerResponse response = new FileManagerResponse();
                        response.Error = new ErrorDetails { Code = "401", Message = "Kök klasör üzerinde değişiklik yapma yetkiniz yoktur!." };
                        return operation.ToCamelCase(response);
                    }
                }
                
            }
            switch (args.Action)
            {

                case "read":
                    // verilen yoldan dosya(lar)ı veya klasör(ler)i okur.
                    return operation.ToCamelCase(operation.GetFiles(args.Path, args.ShowHiddenItems));
                case "delete":
                    //seçilen dosya(lar)ı veya klasör(ler)i verilen yoldan siler.
                    return operation.ToCamelCase(operation.Delete(args.Path, args.Names));
                case "copy":
                    // seçilen dosya(lar)ı veya klasör(ler)i bir yoldan kopyalar ve ardından bunları belirli bir hedef yola yapıştırır.
                    return operation.ToCamelCase(operation.Copy(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "move":
                    // seçilen dosya(lar)ı veya klasör(ler)i bir yoldan keser ve ardından bunları belirli bir hedef yola yapıştırır.
                    return operation.ToCamelCase(operation.Move(args.Path, args.TargetPath, args.Names, args.RenameFiles, args.TargetData));
                case "details":
                    // seçilen dosya(lar)ın veya klasör(ler)in ayrıntılarını alır.
                    return operation.ToCamelCase(operation.Details(args.Path, args.Names, args.Data));
                case "create":
                    // verilen bir yolda yeni bir klasör oluşturur.
                    return operation.ToCamelCase(operation.Create(args.Path, args.Name));
                case "search":
                    // aranan anahtar dizgisine göre belirli bir yoldan dosya(lar)ın veya klasör(ler)in listesini alır.
                    return operation.ToCamelCase(operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                case "rename":
                    // bir dosya veya klasörü yeniden adlandırır.
                    return operation.ToCamelCase(operation.Rename(args.Path, args.Name, args.NewName));
            }
            
            return null;
        }

        // dosyaları belirli bir yola yükler
        [Route("Upload")]
        [Authorize(Roles = "Admin,VideoEkleDuzenle,DosyaEkleDuzenle")]
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
            FileManagerResponse uploadResponse;
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin,VideoEkleDuzenle,DosyaEkleDuzenle"))
            {
                uploadResponse = operation.Upload(path, uploadFiles, action, null);
                if (uploadResponse.Error != null)
                {
                    Response.Clear();
                    Response.ContentType = "application/json; charset=utf-8";
                    Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
                    Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
                }

            }
            else
            {
                return Content("Dosya Yükleme Yetkiniz Yoktur!");
            }

            return Content("");
        }

        // seçilen dosya(lar)ı ve klasör(ler)i indirir
        [Route("Download")]
        public IActionResult Download(string downloadInput)
        {
            FileManagerDirectoryContent args = JsonConvert.DeserializeObject<FileManagerDirectoryContent>(downloadInput);
            return operation.Download(args.Path, args.Names, args.Data);
        }

        // verilen yoldan resim(ler)i alır
        [Route("GetImage")]
        public IActionResult GetImage(FileManagerDirectoryContent args)
        {
            return operation.GetImage(args.Path, args.Id, false, null, null);
        }
    }

}
