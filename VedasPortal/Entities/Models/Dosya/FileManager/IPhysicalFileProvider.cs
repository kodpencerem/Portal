namespace VedasPortal.Entities.Models.Dosya.FileManager
{
    public interface IPhysicalFileProvider : IFileProvider
    {
        void RootFolder(string folderName);
    }

}
