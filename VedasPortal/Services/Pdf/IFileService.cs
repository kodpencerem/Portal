using System.Collections.Generic;
using VedasPortal.Entities.Models.Dosya;

namespace VedasPortal.Services.Pdf
{
    public interface IFileService
    {
        List<Dosya> GetAllPDFs();
    }
}
