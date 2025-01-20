using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ExamenP3SC.Model;

namespace ExamenP3SC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://gateway.marvel.com:443/v1/public/characters?apikey=4cb4474045e2a75fbadc972ba278f1ae";

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            var response = await _httpClient.GetStringAsync(BaseUrl);
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
            return apiResponse.Data.Results;
        }

        private class ApiResponse
        {
            public ApiData Data { get; set; }
        }

        private class ApiData
        {
            public List<Character> Results { get; set; }
        }
    }
}
}
