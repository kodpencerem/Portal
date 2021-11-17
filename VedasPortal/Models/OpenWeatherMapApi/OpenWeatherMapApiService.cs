using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VedasPortal.Models.DataSources.OpenWeatherMapApi;
using VedasPortal.Repository.Interface;

namespace VedasPortal.Models.OpenWeatherMapApi
{
	public class OpenWeatherMapApiService : IHavaTahmin
    {
        private readonly ApiDataSource dataSource;
        private readonly OpenWeatherMapApiResponseConverter apiResponseConverter;

        public OpenWeatherMapApiService()
        {
            dataSource = new ApiDataSource("2c31acc0ea7626cd73deb29ffb1c17ce", "http://api.openweathermap.org/");
            apiResponseConverter = new OpenWeatherMapApiResponseConverter();
        }

        public Task<HavaTahmini[]> HavaTahminiGetir(params string[] sehirler)
        {
            var forecastTasks = new List<Task<HavaTahmini>>();

            foreach (var city in sehirler.AsEnumerable())
            {
                forecastTasks.Add(dataSource.GetWeatherForecastByCityNameAsync(city)
                    .ContinueWith(resp => apiResponseConverter.ConvertToWeatherForecast(resp.Result)));
            }

            return Task.WhenAll(forecastTasks);
        }
    }
}
