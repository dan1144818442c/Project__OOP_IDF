//using System;
//using System.Net.Http;
//using System.Text;
//using System.Text.Json;

//using System.Threading.Tasks;

//public class GeminiApiClient
//{
//    private readonly HttpClient _httpClient;
//    private readonly string _apiKey;

//    public GeminiApiClient(string apiKey)
//    {
//        _httpClient = new HttpClient();
//        _apiKey = apiKey;
//    }

//    public async Task<string> SendPromptAsync(string prompt)
//    {
//        var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

//        var json = $@"
//{{
//  ""contents"": [
//    {{
//      ""parts"": [
//        {{
//          ""text"": ""Create 3 random terrorists with realistic data for a military simulation""
//        }}
//      ]
//    }}
//  ],
//  ""generationConfig"": {{
//    ""responseMimeType"": ""application/json"",
//    ""responseSchema"": {{
//      ""type"": ""ARRAY"",
//      ""items"": {{
//        ""type"": ""OBJECT"",
//        ""properties"": {{
//          ""Firstname"": {{ ""type"": ""STRING"" }},
//          ""Lastname"": {{ ""type"": ""STRING"" }},
//          ""Age"": {{ ""type"": ""INTEGER"" }},
//          ""Rank"": {{ ""type"": ""INTEGER"" }},
//          ""Status"": {{ ""type"": ""STRING"" }},
//          ""RiskLevel"": {{ ""type"": ""INTEGER"" }},
//          ""Weapons"": {{
//            ""type"": ""ARRAY"",
//            ""items"": {{ ""type"": ""STRING"" }}
//          }},
//          ""Location"": {{
//            ""type"": ""OBJECT"",
//            ""additionalProperties"": {{ ""type"": ""STRING"" }}
//          }},
//          ""LastLocation"": {{ ""type"": [""STRING"", ""NULL""] }}
//        }},
//        ""required"": [""Firstname"", ""Lastname"", ""Age"", ""Rank""]
//      }}
//    }}
//  }}
//}}";


//        var content = new StringContent(json, Encoding.UTF8, "application/json");
//        var response = await _httpClient.PostAsync(url, content);

//        if (!response.IsSuccessStatusCode)
//        {
//            var error = await response.Content.ReadAsStringAsync();
//            throw new Exception($"Error {response.StatusCode}: {error}");
//        }

//        var responseContent = await response.Content.ReadAsStringAsync();

//        using (JsonDocument document = JsonDocument.Parse(responseContent))
//        {
//            var root = document.RootElement;

//            var text = root
//                .GetProperty("candidates")[0]
//                .GetProperty("content")
//                .GetProperty("parts")[0]
//                .GetProperty("text")
//                .GetString();

//            return text ?? "No response text";
//        }

//    }
//}


