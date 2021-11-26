using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace VedasPortal.Services.HavaDurumuService
{
    public class HavaDurumuService
    {
        private readonly HttpClient client;

        public HavaDurumuService(HttpClient client)
        {
            this.client = client;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "apikey 1Nr62I2nBJoTO7UuURtoio:7dX73dYEUpYc0JWerTu1rX");
        }
        public async Task<HavaTahminiResult> HavaDurumuGetir(string sehir, DateTime? tarih)
        {
            var response = await client.GetAsync($"https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city={sehir}");
            var result = await response.Content.ReadAsStringAsync();
            var rr = JsonSerializer.Deserialize<HavaTahminiResult>(result);
            if (!rr.success)
            {
                return new HavaTahminiResult(false, "van", new List<HavaTahminiDetay> { new HavaTahminiDetay("12.12.2021", "", "", "", "0", "", "", "", "", "") });
            }
            return rr;

        }
    }
    public record HavaTahminiResult(bool success, string city, List<HavaTahminiDetay> result);
    public record HavaTahminiDetay(string date, string day, string icon, string description, string degree, string status, string min, string max, string night, string humidity);
}
