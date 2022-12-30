using Newtonsoft.Json;

namespace Kuchejda.ZTP.WebApi.Providers
{
    public class JsonProvider : IJsonProvider
    {
        public string Serialize<TBody>(TBody body) where TBody : class
        {
            return JsonConvert.SerializeObject(body);
        }
    }
}
