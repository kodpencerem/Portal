using System;
using System.IO;

namespace VedasPortal
{
    public static class SaveFileToUploaded
    {
        public static string RandomFileName = DateTime.Now.ToShortDateString()
            .Replace(":", "")
            .Replace("/", "")
            .Replace(@"\", "")
            .Replace("-", "")
            .Replace(".", "")
            .ToString() + DateTime.Now.ToShortTimeString()
            .Replace(":", "").Replace("/", "")
            .Replace("-", "").Replace(@"\", "")
            .Replace(".", "").ToString();
        public static string ImageUploadedPath = Path.Combine(System.Environment.CurrentDirectory, "wwwroot", "images", "uploaded");
        public static string FileName { get; set; }
        public static void SaveStreamAsFile(string filePath, Stream inputStream, string fileName)
        {
            filePath = Path.Combine(System.Environment.CurrentDirectory, "wwwroot", "images", "uploaded");
            DirectoryInfo info = new(filePath);
            if (!info.Exists)
            {
                info.Create();
            }

            string path = Path.Combine(filePath, fileName);
            using (FileStream outputFileStream = new(path, FileMode.Create))
            {
                inputStream.CopyTo(outputFileStream);
            }
        }

    }
}
