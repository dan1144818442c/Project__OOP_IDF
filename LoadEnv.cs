using System;
using System.IO;

namespace Project_idf___
{
    public static class EnvLoader
    {
        public static void LoadEnv(string filePath = "api_gemini.env")
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine(".env file not found!");
                return;
            }

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                    continue;

                var index = line.IndexOf('=');
                if (index > -1)
                {
                    string key = line.Substring(0, index).Trim();
                    string value = line.Substring(index + 1).Trim();

                    Environment.SetEnvironmentVariable(key, value);
                }
            }
        }
    }
}
