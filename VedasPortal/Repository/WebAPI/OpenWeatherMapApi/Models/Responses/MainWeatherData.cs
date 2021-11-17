using Newtonsoft.Json;

namespace VedasPortal.Models.DataSources.OpenWeatherMapApi.Models.Responses
{
    [JsonObject]
    public class MainWeatherData
    {
        [JsonProperty("temp")]
        public float Temperature { get; set; }

        [JsonProperty("pressure")]
        public int AtmosphericPressure { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }

        [JsonProperty("temp_min ")]
        public float MinTemperatureAtMoment { get; set; }

        [JsonProperty("temp_max")]
        public float MaxTemperatureAtMoment { get; set; }
    }
}
