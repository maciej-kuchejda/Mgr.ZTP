namespace Kuchejda.ZTP.WebApi.Clients
{
    public interface IQueueClient
    {
        void Post<TBody>(string path, TBody body) where TBody : class;
    }
}
