using DocumentExplorer.Models.FileManager;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using VedasPortal.Data;

namespace VedasPortal.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllOrigins")]
    public class TrashController : ControllerBase
    {
        private PhysicalFileProvider operation;
        private string basePath;
        private string baseLocation;


        public TrashController(IWebHostEnvironment hostingEnvironment)
        {
            basePath = hostingEnvironment.ContentRootPath;
            baseLocation = basePath + "\\wwwroot";
            operation = new PhysicalFileProvider();
        }

        // Processing the File Manager operations
        [Route("FileOperations")]
        public object FileOperations([FromBody] ReadArgs args)
        {
            try
            {
                switch (args.Action)
                {
                    // Özel işleminizi buraya ekleyin
                    case "read":
                        // Path - Şuanki yol; ShowHiddenItems - Gizli öğeleri göstermek/gizlemek için Boole değeri
                        return operation.ToCamelCase(GetFiles());
                    case "search":
                        // Path - Aramanın yapıldığı mevcut yol; SearchString - Arama kutusuna yazılan dize; CaseSensitive - Aramanın büyük/küçük harf duyarlı olması gerekip gerekmediğini belirten Boole değeri
                        //return this.operation.ToCamelCase(this.operation.Search(args.Path, args.SearchString, args.ShowHiddenItems, args.CaseSensitive));
                        return operation.ToCamelCase(SearchFiles(args.SearchString, args.CaseSensitive));
                    case "details":
                        // Path - Dosya/klasör ayrıntılarının istendiği geçerli yol; Ad - İstenen klasörlerin adları
                        return operation.ToCamelCase(GetDetails(args.Data));
                    case "delete":
                        // Path - Silinecek klasörün geçerli yolu; Adlar - Silinecek dosyaların adı
                        return operation.ToCamelCase(DeleteFiles(args.Data));
                    case "rename":
                    case "create":
                    case "move":
                    case "copy":
                        // Path - Yeniden adlandırılan dosyanın geçerli yolu; Ad - Eski dosya adı; NewName - Yeni dosya adı
                        // return this.operation.ToCamelCase(this.operation.Rename(args.Path, args.Name, args.NewName));
                        FileManagerResponse response = new FileManagerResponse();
                        response.Error = new ErrorDetails() { Code = "401", Message = "Restore file to perform this action" };
                        return operation.ToCamelCase(response);
                }
                return null;
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public FileManagerResponse GetFiles()
        {
            FileManagerResponse readResponse = new FileManagerResponse();
            FileManagerDirectoryContent cwd = new FileManagerDirectoryContent();
            string fullPath = baseLocation + "/Trash";
            DirectoryInfo directory = new DirectoryInfo(fullPath);
            cwd.Name = "Trash";
            cwd.Size = 0;
            cwd.IsFile = false;
            cwd.DateModified = directory.LastWriteTime;
            cwd.DateCreated = directory.CreationTime;
            cwd.HasChild = false;
            cwd.Type = directory.Extension;
            cwd.FilterPath = "/";
            cwd.Permission = null;
            readResponse.CWD = cwd;
            string jsonPath = basePath + "\\wwwroot\\User\\trash.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            List<TrashContents> DeletedFiles = JsonConvert.DeserializeObject<List<TrashContents>>(jsonData) ?? new List<TrashContents>();
            List<FileManagerDirectoryContent> files = new List<FileManagerDirectoryContent>();
            foreach (TrashContents file in DeletedFiles)
            {
                files.Add(file.Data);
            }
            readResponse.Files = files;
            return readResponse;
        }
        public FileManagerResponse GetDetails(FileManagerDirectoryContent[] files)
        {
            operation.RootFolder(baseLocation + "\\Trash");
            FileManagerResponse response;
            string[] names = new string[files.Length];
            string responseName = "";
            int index = 0;
            foreach (FileManagerDirectoryContent file in files)
            {
                names[index] = file.Id;
                index++;
                responseName = responseName == "" ? file.Name : responseName + ", " + file.Name;
            }
            response = operation.Details("/", names);
            response.Details.Name = responseName;
            response.Details.Location = "Trash";
            return response;
        }
        public FileManagerResponse DeleteFiles(FileManagerDirectoryContent[] files)
        {
            operation.RootFolder(baseLocation);
            string jsonPath = basePath + "\\wwwroot\\User\\trash.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            List<FileManagerDirectoryContent> responseFiles = new List<FileManagerDirectoryContent>();
            List<TrashContents> DeletedFiles = JsonConvert.DeserializeObject<List<TrashContents>>(jsonData) ?? new List<TrashContents>();
            foreach (FileManagerDirectoryContent file in files)
            {
                TrashContents trashFile = DeletedFiles.Find(x => x.Container.Equals(file.Id));
                string trashPath = "/Trash/" + trashFile.Container;
                DeleteDirectory(baseLocation + trashPath);
                responseFiles.Add(trashFile.Data);
                DeletedFiles.Remove(trashFile);
            }
            jsonData = JsonConvert.SerializeObject(DeletedFiles);
            System.IO.File.WriteAllText(jsonPath, jsonData);
            return new FileManagerResponse() { Files = responseFiles };
        }
        [Route("EmptyTrash")]
        public IActionResult EmptyTrash()
        {
            string jsonPath = basePath + "\\wwwroot\\User\\trash.json";
            string jsonData = "";
            string[] dirs = Directory.GetDirectories(baseLocation);
            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }
            System.IO.File.WriteAllText(jsonPath, jsonData);
            return Content("");
        }

        [Route("Restore")]
        public IActionResult Restore([FromBody] FileManagerDirectoryContent[] files)
        {
            operation.RootFolder(baseLocation);
            string jsonPath = basePath + "\\wwwroot\\User\\trash.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            string responseString = "";
            List<TrashContents> DeletedFiles = JsonConvert.DeserializeObject<List<TrashContents>>(jsonData) ?? new List<TrashContents>();
            foreach (FileManagerDirectoryContent file in files)
            {
                TrashContents trashFile = DeletedFiles.Find(x => x.Container.Equals(file.Id));
                string fileLocation = "/Files" + trashFile.Path;
                string trashPath = "/Trash/" + trashFile.Container;
                FileManagerResponse response = operation.Move(trashPath, fileLocation, new string[] { trashFile.Name }, new string[] { trashFile.Name }, null, null);
                if (response.Error == null)
                {
                    DeleteDirectory(baseLocation + trashPath);
                    DeletedFiles.Remove(trashFile);
                    responseString = "Restored";
                }
                else
                {
                    responseString = "Restore Failed";
                }
            }
            jsonData = JsonConvert.SerializeObject(DeletedFiles);
            System.IO.File.WriteAllText(jsonPath, jsonData);
            return Content(responseString);
        }

        public FileManagerResponse SearchFiles(string value, bool caseSensitive)
        {
            operation.RootFolder(baseLocation);
            string jsonPath = basePath + "\\wwwroot\\User\\trash.json";
            string jsonData = System.IO.File.ReadAllText(jsonPath);
            List<TrashContents> DeletedFiles = JsonConvert.DeserializeObject<List<TrashContents>>(jsonData) ?? new List<TrashContents>();
            List<TrashContents> searchFiles = DeletedFiles.FindAll(x => new Regex(WildcardToRegex(value), caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).IsMatch(x.Name));
            List<FileManagerDirectoryContent> data = new List<FileManagerDirectoryContent>();
            foreach (TrashContents file in searchFiles)
            {
                data.Add(file.Data);
            }
            return new FileManagerResponse() { Files = data };
        }
        public virtual string WildcardToRegex(string value)
        {
            return "^" + Regex.Escape(value).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";
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
    public class TrashContents
    {
        public string Container { get; set; }
        public DateTime DateDeleted { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public FileManagerDirectoryContent Data { get; set; }
    }

}