using System;
using System.Net.Http;
using System.Net.Http.Headers;

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
        public void HavaDurumuGetir(string sehir, DateTime? tarih)
        {
            var response= client.GetAsync($"https://api.collectapi.com/weather/getWeather?data.lang=tr&data.city={sehir}").GetAwaiter().GetResult();
             var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
    }
}
