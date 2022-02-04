﻿using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace VedasPortal.Services.FileUploadDownload
{
    public interface IFileUpload
    {
        // method to upload file
        Task UploadFile(IBrowserFile file);
        // method to generate preview url
        Task<string> GeneratePreviewUrl(IBrowserFile file);
    }

    public class FileUpload : IFileUpload
    {

        private IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<FileUpload> _logger;

        // On creation of the FileUpload class, we shall inject the web host environment and logger object
        // the web host environment contains information about the environment the app is running in like file location
        // the logger object will be used to log info, errors, warnings e.t.c
        public FileUpload(IWebHostEnvironment webHostEnvironment, ILogger<FileUpload> logger)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> GeneratePreviewUrl(IBrowserFile file)
        {
            // We can only preview images so for other file types,
            // we shall use the content type logos in the images folder
            if (!file.ContentType.Contains("image"))
            {
                // For example, for pdf, we are going to use a logo of a pdf file in the preview
                if (file.ContentType.Contains("pdf"))
                {
                    return "img/pdf_logo.png";
                }
            }

            // resize the image to a preview
            var resizedImage = await file.RequestImageFileAsync(file.ContentType, 100, 100);

            // set buffer size to new resized image size
            var buffer = new byte[resizedImage.Size];

            // read the resized image
            await resizedImage.OpenReadStream().ReadAsync(buffer);

            //generate url and add it to preview list
            return $"data:{file.ContentType};base64,{Convert.ToBase64String(buffer)}";
        }

        public async Task UploadFile(IBrowserFile file)
        {
            // make sure the file is valid
            if (file is not null)
            {
                try
                {
                    // Create upload path for the file using its name
                    var uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "img/uploaded", file.Name);
                    // create and open a stream to upload the file
                    using (var stream = file.OpenReadStream())
                    {
                        // create write access to the upload path
                        var fileStream = File.Create(uploadPath);
                        // read from the local path and writes to upload path 
                        await stream.CopyToAsync(fileStream);
                        // close stream and release resources
                        fileStream.Close();
                    }
                }
                catch (Exception ex)
                {
                    // Log and handle the exception
                    _logger.LogError(ex.ToString());
                }

            }

        }
    }
}
