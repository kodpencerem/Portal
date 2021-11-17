using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using VedasPortal.Models.DataSources.OpenWeatherMapApi.Models.Responses;

namespace VedasPortal.Models.DataSources.OpenWeatherMapApi
{
    public class ApiDataSource
    {
        private readonly string appId;
        private readonly HttpClient weatherApiClient;

        public ApiDataSource(string appId, string baseApiUrl)
        {
            this.appId = appId;

            weatherApiClient = new HttpClient
            {
                BaseAddress = new Uri(baseApiUrl)
            };
        }

        public async Task<CurrentForecastResponse> GetWeatherForecastByCityNameAsync(string cityName)
        {
            var responseMessage = await weatherApiClient.GetAsync(createQueryString(cityName));

            if (!responseMessage.IsSuccessStatusCode)
            {
                return createCityNotFoundResponse();
            }

            var responseContentString = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CurrentForecastResponse>(responseContentString);
        }

        private static CurrentForecastResponse createCityNotFoundResponse()
        {
            return new CurrentForecastResponse
            {
                CityName = "Aradığınız şehir bulunamadı!!",
                System = new SystemData
                {
                    Country = "Nowhere"
                }
            };
        }

        private string createQueryString(string cityName)
        {
            return $"data/2.5/weather?q={cityName}&appid={appId}";
        }
    }
}
