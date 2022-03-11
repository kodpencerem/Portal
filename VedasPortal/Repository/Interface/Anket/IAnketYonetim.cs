using Ardalis.Result;
using System.Collections.Generic;
using System.Threading.Tasks;
using VedasPortal.Entities.DTOs.Anket;

namespace VedasPortal.Repository.Interface.Anket
{
    public interface IAnketYonetim
    {
        Result<AnketDTO> AnketGetir(int id);
        Task<Result<AnketDTO>> AnketGetirAsync(int id);
        Result<List<AnketDTO>> TumAnketleriGetir();
        Task<Result<List<AnketDTO>>> TumAnketleriGetirAsync();
        Result<bool> AnketSil(int id);
        Task<Result<bool>> AnketSilAsync(int id);
        Result<AnketDTO> RastGeleAnketGetir();
        Task<Result<AnketDTO>> RastGeleAnketGetirAsync();
        Result<AnketDTO> AnketEkle(AnketDTO survey);
        Task<Result<AnketDTO>> AnketEkleAsync(AnketDTO survey);
        Result<bool> AnketDuzenle(AnketDTO survey);
        Task<Result<bool>> AnketDuzenleAsync(AnketDTO survey);
        Result<AnketDTO> EnPopulerAnket();
        Task<Result<AnketDTO>> EnPopulerAnketAsync();

    }
}