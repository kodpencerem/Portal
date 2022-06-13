using BlazorInputFile;
using System.Threading.Tasks;

namespace VedasPortal.Services.Pdf
{
    public interface IPdfUpload
    {
        Task Upload(IFileListEntry file);
    }
}
