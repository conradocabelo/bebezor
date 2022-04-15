using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace Bebezor.Sample.Services.BaseService
{
    public abstract class BaseService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public BaseService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient() 
            { 
                BaseAddress = new Uri(_configuration.GetValue<string>("base-api")) 
            };
        }

        private string TimeStamp() => DateTime.Now.ToString("yyyyMMddHHmmssffff");

        private string Hash(string timestamp)
        {
            var baseHash = $"{timestamp}{_configuration.GetValue<string>("private-key")}{_configuration.GetValue<string>("public-key")}";
            using (MD5 hash = MD5.Create())
            {
                var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(baseHash));
                var formatedHash = BitConverter.ToString(bytes).Replace("-", "");
                return formatedHash.ToLower();
            }
        }

        private string AuthParameters()
        {
            var timeStamp = TimeStamp();
            var hash = Hash(timeStamp);

            return $"ts={timeStamp}&apikey={_configuration.GetValue<string>("public-key")}&hash={hash}";
        }

        private string CreateEndpoint(string Method) =>
            $"v1/public/{Method}?{AuthParameters()}";

        public async Task<TObjectReturn> GetAsync<TObjectReturn>(string Method) where TObjectReturn : class
        {
            using (var httpResponse = await _httpClient.GetAsync(CreateEndpoint(Method)))
            {
                if (!httpResponse.IsSuccessStatusCode)
                {
                    string errorMessage = httpResponse.ReasonPhrase;
                    Console.WriteLine($"There was an error! {errorMessage}");
                    return null;
                }

                var responseJson = await httpResponse.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TObjectReturn>(responseJson);
            }
        }
    }
}
