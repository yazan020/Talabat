using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TalabatApi.Domain.Model;
using Ubiety.Dns.Core;

namespace TalabatApi.NetworkRequests
{
    public class GetClientAddress
    {
        private HttpClient _httpClient;

        public GetClientAddress()
        {
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }


        public async Task<string> GetGeoInfo()
        {
            string addressInfo = await GetIpAddress();

            var response = await _httpClient.GetAsync($"http://api.ipstack.com/"+addressInfo+"?access_key=4fbe492b788b97fd4e6e67a5bb93909c&format=1");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }

            return response.StatusCode.ToString();
        }

        public async Task<string> GetIpAddress()
        {
            var ipAddress = await _httpClient.GetAsync($"http://ipinfo.io/ip");

            if (ipAddress.IsSuccessStatusCode)
            {
                var json = await ipAddress.Content.ReadAsStringAsync();
                return json.ToString();
            }

            return ipAddress.StatusCode.ToString();
        }
    }
}