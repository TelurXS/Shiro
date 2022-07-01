using Newtonsoft.Json;

namespace Shiro
{
    public class Config
    {
        [JsonProperty("token")] public string Token { get; private set; }
        [JsonProperty("prefix")] public string Prefix { get; private set; }

        public Config(string token, string prefix)
        {
            Token = token;
            Prefix = prefix;
        }

        public static Config Read(string fileName) 
        {
            if (File.Exists(fileName))
            {
                Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(fileName));

                Validate("Token", config.Token);
                Validate("Prefix", config.Prefix);

                return config;
            }
            else throw new ArgumentException($"File {fileName} is not exsist. Can`t read values.");
        }

        private static void Validate(string name, string value) 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{name} string is empty or null");
            }
        }
    }
}
