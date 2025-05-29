using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_idf___
{
    public class GeminiApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public GeminiApiClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> SendPromptAsync(string prompt)
        {
            var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

            var json = $@"
            {{
                ""contents"": [
                    {{
                        ""parts"": [
                            {{
                                ""text"": ""{prompt}""
                            }}
                        ]
                    }}
                ]
            }}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error {response.StatusCode}: {error}");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
