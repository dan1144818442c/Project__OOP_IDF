//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Project_idf___
//{
//    public static class GeminiExecutor
//    {
//        public static async Task RunAsync()
//        {
//            EnvLoader.LoadEnv();

//            string apiKey = Environment.GetEnvironmentVariable("API_KEY");
//            if (string.IsNullOrWhiteSpace(apiKey))
//            {
//                Console.WriteLine("Missing API_KEY in .env");
//                return;
//            }

//            var client = new GeminiApiClient(apiKey);

//            try
//            {
//                string response = await client.SendPromptAsync( Console.ReadLine()); ;
//                Console.WriteLine("Response:\n" + response);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error: " + ex.Message);
//            }
//        }
//    }

//}
