using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace VedasPortal.Services.FileUploadDownload
{
    // interface to define what the upload service will do
    public interface IFileDownload
    {
        // method to get all files in our uploads folder and return a base64 url for each
        Task<List<string>> GetUploadedFiles();
        // method to download a file from the server
        Task DownloadFile(string url);
    }
    public class FileDownload : IFileDownload
    {
        private IWebHostEnvironment _webHostEnvironment;
        private readonly IJSRuntime _js;
        public FileDownload(IWebHostEnvironment webHostEnvironment, IJSRuntime js)
        {
            // On creation of the FileDownload class, we shall inject the web host environment 
            // the web host environment contains information about the environment the app is running in like file location
            _webHostEnvironment = webHostEnvironment;
            // javascript runtime that enables executing js functions in .NET
            _js = js;
        }

        public async Task DownloadFile(string url)
        {
            // invoke the javascript method to download the file
            await _js.InvokeVoidAsync("downloadFile", url);
        }

        // implementation of GetUploadedFiles method from the interface
        public async Task<List<string>> GetUploadedFiles()
        {
            // initialise an empty list that will hold base64 urls of files read from the server
            var base64Urls = new List<string>();
            // Create upload path for the file using its name
            var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");

            //Get all files from this uploads folder
            var files = Directory.GetFiles(uploadPath);

            // make sure the upload path has a file in it 
            if (files is not null && files.Length > 0)
            {
                // loop through all files in the upload folder read the file and get its base64 url
                foreach (var filepath in files)
                {
                    // read each file in the uploads folder
                    using (var fileInput = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                    {
                        // create a memory stream 
                        var memorystream = new MemoryStream();
                        // copy the file to a memory stream
                        await fileInput.CopyToAsync(memorystream);

                        // convert our memory stream to bytes 
                        var buffer = memorystream.ToArray();

                        // get the MIME file Extension
                        var fileType = GetMimeTypeForFileExtension(filepath);

                        // create a base64 url string from the byte array and add it to our list of urls
                        base64Urls.Add($"data:{fileType};base64,{Convert.ToBase64String(buffer)}");
                    }
                }
            }
            // return our base64 urls
            return base64Urls;
        }

        // Helper method to get the MIME Type for the file
        private string GetMimeTypeForFileExtension(string filePath)
        {
            // define a default content type 
            const string DefaultContentType = "application/octet-stream";

            var provider = new FileExtensionContentTypeProvider();
            // Given path, get the MIME type or use the default
            if (!provider.TryGetContentType(filePath, out string contentType))
            {
                contentType = DefaultContentType;
            }

            return contentType;
        }
    }
}
