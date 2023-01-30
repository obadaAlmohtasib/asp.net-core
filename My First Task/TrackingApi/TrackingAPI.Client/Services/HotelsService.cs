using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace TrackingAPI.Client.Services
{
    public class HotelsService
    {
        private readonly HttpClient _httpClient;
        private const String API_URI = "https://localhost:7087/api/HotelsService";
        private const String MEDIA_TYPE = "application/json";

        public HotelsService() { 
            _httpClient = new HttpClient();
        }

        public async Task<Object> GetLatestHotelsDeals() {
            return await GetJSON($"{API_URI}");
        }

        public async Task<Object> SearchForHotels(string query)
        {            
            return await GetJSON($"{API_URI}/query?query={query}");
        }

        private async Task<Object> GetJSON(string path) { 
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MEDIA_TYPE));
            HttpResponseMessage response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Object>();
            }
            else
            {
                return new Object();
            }
        }

    }
}
