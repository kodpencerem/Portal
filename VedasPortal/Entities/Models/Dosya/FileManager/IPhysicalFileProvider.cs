namespace DocumentExplorer.Models.FileManager
{
    public interface IPhysicalFileProvider : IFileProvider
    {
        void RootFolder(string folderName);
    }

}
