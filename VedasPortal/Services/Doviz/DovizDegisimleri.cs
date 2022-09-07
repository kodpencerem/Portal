using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using VedasPortal.Entities.Models.DovizKurlari;

namespace VedasPortal.Services.Doviz
{
    public class DovizDegisimleri
    {
        private readonly HttpClient client;
        List<DovizKur> CurList = null;
        public DovizDegisimleri(HttpClient client)
        {
            this.client = client;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<DovizKur> DovizKuruGetir()
        {
            var response = await client.GetAsync($"https://api.genelpara.com/embed/altin.json");
            var result = await response.Content.ReadAsStringAsync();
            CurList  = JsonConvert.DeserializeObject<List<DovizKur>>(result);

            if (CurList == null)
                return null;
            return default;
        }
    }
}
