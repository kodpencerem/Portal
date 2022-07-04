using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VedasPortal.Data;
using VedasPortal.Entities.Models.Dosya.FileManager;

namespace VedasPortal.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class FileManagerController : ControllerBase
    {
        private PhysicalFileProvider operation;
        private string basePath;
        public FileManagerController(IWebHostEnvironment hostingEnvironment)
        {
            basePath = hostingEnvironment.ContentRootPath;
            operation = new PhysicalFileProvider();
            operation.RootFolder(basePath + "\\wwwroot\\Files"); // Data\\Dosyalar, hangi dosya ve klasörlerin mevcut olduðunu belirtir.
        }
        // Dosya Yöneticisi iþlemlerinin iþlenmesi
        [Route("FileOperations")]
        public object FileOperations([FromBody] FileManagerCustomContent args)
        {
            switch (args.Action)
            {
                // Özel iþleminizi buraya ekleyin
                case "read":
                    if (args.RootType != null && args.RootType == "Recent" /*|| (args.RootType == "Starred")*/)
                    {
                        FileManagerResponse result1 = operation.Search(args.Path, "*", args.ShowHiddenItems, false);
                        result1 = FilterRecentFiles(result1);
                        return AddStarDetails(result1);
                    }
                    else if (args.RootType != null && args.RootType == "Starred")
                    {
                        return FilterStarred(operation.Search(args.Path, "*", args.ShowHiddenItems, false));
                    }
                    else
                    {
                        return AddStarDetails(operation.GetFiles(args.Path, args.ShowHiddenItems));
                    }
                case "delete":
                    FileManagerDirectoryContent[] items1 = args.Data;
                    string[] names1 = args.Names;
                    for (var i = 0; i < items1.Length; i++)
                    {
                        names1[i] = (items1[i].FilterPath + items1[i].Name).Substring(1);
                        RemoveStarred(names1[i]);
                    }
                    return operation.ToCamelCase(MoveToTrash(args.Data));
                case "copy":
                case "move":
                    FileManagerResponse response = new FileManagerResponse();
                    response.Error = new ErrorDetails() { Code = "401", Message = "Restricted to perform this action" };
                    return operation.ToCamelCase(response);
                case "details":
                    if (args.RootType != null && (args.RootType == "Recent" || args.RootType == "Starred"))
                    {
                        FileManagerDirectoryContent[] items = args.Data;
                        string[] names = args.Names;
                        for (var i = 0; i < items.Length; i++)
                        {
                            names[i] = (items[i].FilterPath + items[i].Name).Substring(1);
                        }
                        return operation.ToCamelCase(operation.Details("/", names, args.Data));
                    }
                    else
                    {
                        return operation.ToCamelCase(operation.Details(args.Path, args.Names, args.Data));
                    }
                case "create":
                    // Path - Klasörün oluþturulacaðý geçerli yol; Ad - Yeni klasörün adý
                    return operation.ToCamelCase(operation.Create(args.Path, args.Name));
                case "search":
                    // Path - Aramanýn yapýldýðý mevcut yol; SearchString - Arama kutusuna yazýlan dize; CaseSensitive - Aramanýn büyük/küçük harf duyarlý olmasý gerekip gerekmediðini belirten Boole deðeri                    
                    if (args.RootType != null && args.RootType == "Recent")
                    {
                        FileManagerResponse result1 = operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive);
                        result1 = FilterRecentFiles(result1);
                        return AddStarDetails(result1);
                    }
                    else if (args.RootType != null && args.RootType == "Starred")
                    {
                        return FilterStarred(operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                    }
                    else
                    {
                        return AddStarDetails(operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                    }
                case "rename":
                    // Path - Yeniden adlandýrýlan dosyanýn geçerli yolu; Ad - Eski dosya adý; NewName - Yeni dosya adý
                    if (args.RootType != null && args.RootType == "Recent")
                    {
                        var items = args.Data;
                        var name = (items[0].FilterPath + items[0].Name).Substring(1);
                        var newName = (items[0].FilterPath + args.NewName).Substring(1);
                        return operation.ToCamelCase(operation.Rename("/", name, newName));
                    }
                    else
                    {
                        return operation.ToCamelCase(operation.Rename(args.Path, args.Name, args.NewName));
                    }
            }
            return null;
        }
        public FileManagerResponse FilterRecentFiles(FileManagerResponse result)
        {
            IEnumerable<FileManagerDirectoryContent> allFiles = result.Files;
            allFiles = allFiles?.Where(item => item.DateModified.AddDays(5).CompareTo(DateTime.Now) != -1 && item.IsFile == true);
            result.Files = allFiles;
            return result;
        }
        public FileManagerResponse MoveToTrash(FileManagerDirectoryContent[] dataArray)
        {
            string jsonPath = basePath + "\\wwwroot\\User\\trash.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            List<TrashContents> DeletedFiles = JsonConvert.DeserializeObject<List<TrashContents>>(jsonData) ?? new List<TrashContents>();
            PhysicalFileProvider trashOperation = new PhysicalFileProvider();
            string root = basePath + "\\wwwroot";
            trashOperation.RootFolder(root);
            List<FileManagerDirectoryContent> deletedFiles = new List<FileManagerDirectoryContent>();
            foreach (FileManagerDirectoryContent data in dataArray)
            {
                string fileLocation = "/Files" + data.FilterPath;
                DateTime deleteTime = DateTime.Now;
                string container = deleteTime.ToFileTimeUtc().ToString();
                string trashPath = "/Trash/" + container;
                Directory.CreateDirectory(root + trashPath);
                FileManagerResponse response = trashOperation.Move(fileLocation, trashPath, new string[] { data.Name }, null, null, null);
                if (response.Error == null)
                {
                    TrashContents deletedFile = new TrashContents()
                    {
                        Container = container,
                        Data = data,
                        DateDeleted = deleteTime,
                        Name = data.Name,
                        Path = data.FilterPath
                    };
                    deletedFile.Data.DateModified = deletedFile.DateDeleted;
                    deletedFile.Data.Id = deletedFile.Container;
                    DeletedFiles.Add(deletedFile);
                    deletedFiles.Add(response.Files.First());
                }
            }
            jsonData = JsonConvert.SerializeObject(DeletedFiles);
            System.IO.File.WriteAllText(jsonPath, jsonData);
            return new FileManagerResponse() { Files = deletedFiles };
        }
        public string AddStarDetails(FileManagerResponse value)
        {
            string jsonPath = basePath + "\\wwwroot\\User\\star.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            List<string> starredFiles = JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
            FileResponse readResponse = new FileResponse();
            readResponse.CWD = value.CWD;
            readResponse.Files = JsonConvert.DeserializeObject<IEnumerable<FileManagerCustomContent>>(JsonConvert.SerializeObject(value.Files));
            foreach (FileManagerCustomContent file in readResponse.Files)
            {
                file.FilterPath = file.FilterPath.Replace(Path.DirectorySeparatorChar, '/');
                file.Starred = starredFiles.Contains(file.FilterPath + file.Name);
            }
            readResponse.Details = value.Details;
            readResponse.Error = value.Error;
            return JsonConvert.SerializeObject(readResponse, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() } });
        }
        public string FilterStarred(FileManagerResponse value)
        {
            string jsonPath = basePath + "\\wwwroot\\User\\star.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            List<string> starredFiles = JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
            FileResponse readResponse = new FileResponse();
            readResponse.CWD = value.CWD;
            List<FileManagerCustomContent> files = new List<FileManagerCustomContent>();
            List<FileManagerCustomContent> allFiles = JsonConvert.DeserializeObject<List<FileManagerCustomContent>>(JsonConvert.SerializeObject(value.Files));
            foreach (FileManagerCustomContent file in allFiles)
            {
                file.FilterPath = file.FilterPath.Replace(Path.DirectorySeparatorChar, '/');
                if (starredFiles.Contains(file.FilterPath + file.Name))
                {
                    file.Starred = true;
                    files.Add(file);
                }
            }
            readResponse.Files = files;
            readResponse.Details = value.Details;
            readResponse.Error = value.Error;
            return JsonConvert.SerializeObject(readResponse, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() } });
        }
        public void RemoveStarred(string filePath)
        {
            string jsonPath = basePath + "\\wwwroot\\User\\star.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            List<string> starredFiles = JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
            string path = filePath.Replace(Path.DirectorySeparatorChar, '/');
            if (starredFiles.Contains(path))
            {
                starredFiles.Remove(path);
            }
            jsonData = JsonConvert.SerializeObject(starredFiles);
            System.IO.File.WriteAllText(jsonPath, jsonData);
        }
        [Route("Upload")]
        public IActionResult Upload(string path, IList<IFormFile> uploadFiles, string action)
        {
#if Publish
            //Restrict the upload functionality for publish settings
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.StatusCode = 403;
            Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "The upload functionality is restricted in this online demo. To test this demo application with upload functionality, please download the source code from the GitHub location (https://github.com/syncfusion/blazor-showcase-document-explorer) and run it.";
#else
            FileManagerResponse uploadResponse;
            uploadResponse = operation.Upload(path, uploadFiles, action, null);
            if (uploadResponse.Error != null)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.StatusCode = Convert.ToInt32(uploadResponse.Error.Code);
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = uploadResponse.Error.Message;
            }
#endif
            return Content("");
        }

        [Route("Download")]
        public IActionResult Download(string downloadInput)
        {
            FileManagerDirectoryContent args = JsonConvert.DeserializeObject<FileManagerDirectoryContent>(downloadInput);
            FileManagerDirectoryContent[] items = args.Data;
            string[] names = args.Names;
            for (var i = 0; i < items.Length; i++)
            {
                names[i] = (items[i].FilterPath + items[i].Name).Substring(1);
            }
            return operation.Download("/", names);
        }

        [Route("ToggleStarred")]
        public IActionResult ToggleStarred([FromBody] FileManagerCustomContent args)
        {
            string jsonPath = basePath + "\\wwwroot\\User\\star.json";
            StreamReader reader = new StreamReader(jsonPath);
            string jsonData = reader.ReadToEnd();
            reader.Dispose();
            List<string> starredFiles = JsonConvert.DeserializeObject<List<string>>(jsonData) ?? new List<string>();
            string path = args.Path.Replace(Path.DirectorySeparatorChar, '/');
            if (args.Starred && !starredFiles.Contains(path))
            {
                starredFiles.Add(path);
            }
            else if (!args.Starred && starredFiles.Contains(path))
            {
                starredFiles.Remove(path);
            }
            jsonData = JsonConvert.SerializeObject(starredFiles);
            System.IO.File.WriteAllText(jsonPath, jsonData);
            return Content("");
        }

        [Route("GetImage")]
        public IActionResult GetImage(FileManagerDirectoryContent args)
        {
            return operation.GetImage(args.Path, args.Id, false, null, null);
        }

        public class FileManagerCustomContent : FileManagerDirectoryContent
        {
            public string RootType { get; set; }

            //Custom parameter inidicating starred files
            public bool Starred { get; set; }
        }
        public class FileResponse
        {
            public FileManagerDirectoryContent CWD { get; set; }

            public IEnumerable<FileManagerCustomContent> Files { get; set; }

            public ErrorDetails Error { get; set; }

            public FileDetails Details { get; set; }

        }
        public class TrashContents
        {
            public string Container { get; set; }
            public DateTime DateDeleted { get; set; }
            public string Path { get; set; }
            public string Name { get; set; }
            public FileManagerDirectoryContent Data { get; set; }
        }
    }
}