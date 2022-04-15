using System.Security.Cryptography;
using System.Text;

namespace Bebezor.Sample.Services.BaseService
{
    public abstract class BaseService
    {
        private readonly IConfiguration _configuration;

        public BaseService(IConfiguration configuration) =>
            _configuration = configuration;

        private string TimeStamp() => DateTime.Now.ToString("yyyyMMddHHmmssffff");

        private string Hash(string TimeStamp)
        {
            var baseHash = $"{TimeStamp}{_configuration.GetValue<string>("private-key")}{_configuration.GetValue<string>("public-key")}";
            using (MD5 hash = MD5.Create())
            {
                var bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(baseHash));
                var formatedHash = BitConverter.ToString(bytes).Replace("-", "");
                return formatedHash.ToLower();
            }
        }

        private string GetAcessToken()
        {
            var timeStamp = TimeStamp();
        }
    }
}
