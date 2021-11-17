using Newtonsoft.Json;

namespace VedasPortal.Models.DataSources.OpenWeatherMapApi.Models.Responses
{
    [JsonObject]
    public class Clouds
    {
        [JsonProperty("all")]
        public int Cloudiness { get; set; }
    }
}
