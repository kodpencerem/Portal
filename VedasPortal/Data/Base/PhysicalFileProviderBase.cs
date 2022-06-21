namespace SfFileService.FileManager.Base
{
    public interface PhysicalFileProviderBase : FileProviderBase
    {        
        void RootFolder(string folderName);       
        void SetRules(AccessDetails details);
    }
}
