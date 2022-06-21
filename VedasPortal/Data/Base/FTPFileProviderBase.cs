namespace SfFileService.FileManager.Base
{
    public interface FTPFileProviderBase : FileProviderBase
    {
        void SetFTPConnection(string hostName, string userName, string password);
    }

}
