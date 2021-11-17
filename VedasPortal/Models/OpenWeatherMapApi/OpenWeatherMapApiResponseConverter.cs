using System;
using VedasPortal.Models.DataSources.OpenWeatherMapApi.Models.Responses;

namespace VedasPortal.Models.OpenWeatherMapApi
{
	public class OpenWeatherMapApiResponseConverter
    {
        public HavaTahmini ConvertToWeatherForecast(CurrentForecastResponse response)
        {
            return new HavaTahmini
            {
                Sehir = $"{response.CityName}, {response.System.Country}",
                BulutOrani = response.Clouds?.Cloudiness ?? 0,
                Tarih = DateTime.FromFileTimeUtc(response?.DateUtc ?? DateTime.Now.ToFileTimeUtc()),
                NemOrani = response.Main?.Humidity ?? 0,
                BasincDegeri = response.Main?.AtmosphericPressure ?? 0,
                DereceC = (int)(response.Main?.Temperature ?? 0) - 273,
                RuzgarHizi = (int)(response.Wind?.Speed ?? 0)
            };
        }
    }
}
