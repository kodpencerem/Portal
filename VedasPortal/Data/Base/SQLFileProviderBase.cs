﻿namespace SfFileService.FileManager.Base
{
    public interface SQLFileProviderBase : FileProviderBase
    {
        void SetSQLConnection(string connectionStringName, string tableName, string tableID);
    }

}
