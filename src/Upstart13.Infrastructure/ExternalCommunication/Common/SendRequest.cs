using Newtonsoft.Json;
using Upstart13.Infrastructure.ExternalCommunication.Interfaces;

namespace Upstart13.Infrastructure.ExternalCommunication.Common
{
    public class SendRequest : ISendRequest
    {
        public async Task<T> GetAsync<T>(string url)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "(github.com/gasma, gabriel.moreira.alvarenga@gmail.com)");
            var result = await httpClient.GetAsync(url);
            var content = await result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public Task<T> PostAsync<T>(string url, string payload)
        {
            throw new NotImplementedException();
        }
    }
}
