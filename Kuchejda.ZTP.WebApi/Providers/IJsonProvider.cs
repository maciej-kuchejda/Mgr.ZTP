namespace Kuchejda.ZTP.WebApi.Providers
{
    public interface IJsonProvider
    {
        string Serialize<TBody>(TBody body) where TBody : class;
    }
}
