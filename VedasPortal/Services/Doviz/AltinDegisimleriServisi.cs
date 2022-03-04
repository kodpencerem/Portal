using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VedasPortal.Services.Doviz
{
    public class AltinDegisimleriServisi
    {    
        protected readonly HttpClient client;      
        public AltinDegisimleriServisi(HttpClient client)
        {
            this.client = client;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AltinDegisim> AltinDegisiminiGetir(string satis, string alis, string degisim )
        {
            if (satis is null)
            {
                throw new ArgumentNullException(nameof(satis));
            }

            if (alis is null)
            {
                throw new ArgumentNullException(nameof(alis));
            }

            if (degisim is null)
            {
                throw new ArgumentNullException(nameof(degisim));
            }

            var response = await client.GetAsync($"https://api.genelpara.com/embed/altin.json");
            var result = await response.Content.ReadAsStringAsync();
            var serializeDeserialize = System.Text.Json.JsonSerializer.Deserialize<AltinDegisim>(result);
            if (!serializeDeserialize.Success)
            {
                return new AltinDegisim(false,"GA", new List<GramAltin> { new GramAltin("", "", "") });
                    
            }
            return serializeDeserialize;

        }

        public record AltinDegisim(bool Success, string AltinAdi, /*string Satis, string Alis, string Degisim,*/ List<GramAltin> result);
        public record GramAltin(
        [property: JsonPropertyName("satis")] string Satis,
        [property: JsonPropertyName("alis")] string Alis,
        [property: JsonPropertyName("degisim")] string Degisim);

        public record AltinFiyat(
        [property: JsonPropertyName("GA")] GramAltin GA);
    }
}
