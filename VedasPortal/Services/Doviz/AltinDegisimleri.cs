using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace VedasPortal.Services.Doviz
{
    public class AltinDegisimleri
    {
        private readonly HttpClient client;

        public AltinDegisimleri(HttpClient client)
        {
            this.client = client;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "apikey 5seVX56XQ4WZLNvCkLDU3U:6zC5nR9b3FNGfIvl0cEhNi");
        }
        public async Task<DovizDegisimleriResult> DovizDegisimleriniGetir(string code, DateTime? lastupdate)
        {
            var response = await client.GetAsync($"https://api.collectapi.com/economy/currencyToAll?int=10&base={code}");
            var result = await response.Content.ReadAsStringAsync();
            var rr = JsonSerializer.Deserialize<DovizDegisimleriResult>(result);
            if (!rr.success)
            {
                return new DovizDegisimleriResult(false, "USD", new List<DovizDegisimDetay> { new DovizDegisimDetay("12.12.2021", "", "") });
            }
            return rr;

        }
    }
    public record DovizDegisimleriResult(bool success, string code, List<DovizDegisimDetay> result);
    public record DovizDegisimDetay(string name, string buy, string sell);
}
