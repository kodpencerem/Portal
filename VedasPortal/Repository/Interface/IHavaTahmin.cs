using System.Threading.Tasks;
using VedasPortal.Models.OpenWeatherMapApi;

namespace VedasPortal.Repository.Interface
{
    public interface IHavaTahmin
    {
        Task<HavaTahmini[]> HavaTahminiGetir(params string[] sehirler);
    }
}
