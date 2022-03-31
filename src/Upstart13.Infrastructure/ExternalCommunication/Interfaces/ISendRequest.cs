namespace Upstart13.Infrastructure.ExternalCommunication.Interfaces
{
    public interface ISendRequest
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, string payload);
    }
}
