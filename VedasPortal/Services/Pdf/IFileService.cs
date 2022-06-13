using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Services.Pdf
{
    public interface IFileService
    {
        List<FileClass> GetAllPDFs();
    }
}
