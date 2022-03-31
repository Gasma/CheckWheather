using Microsoft.Extensions.Options;
using Upstart13.Infrastructure.ExternalCommunication.CommunicationModels;
using Upstart13.Infrastructure.ExternalCommunication.Interfaces;

namespace Upstart13.Infrastructure.ExternalCommunication.CommunicationService
{
    public class WeatherService : IWeatherService
    {
        private readonly ISendRequest sendRequest;
        private readonly string GeocodingUrl;
        private readonly string ApiWheatherUrl;

        public WeatherService(ISendRequest _sendRequest, IOptions<ExternalUrls> options)
        {
            sendRequest = _sendRequest;
            ApiWheatherUrl = options.Value.ApiWheatherUrl;
            GeocodingUrl = options.Value.GeocodingUrl;
        }

        public async Task<GeocodingResultModel> QueryGeocodding(string query)
        {
            return await sendRequest.GetAsync<GeocodingResultModel>(string.Format(GeocodingUrl, query));
        }

        public async Task<ApiWheatherForecastResultModel> QueryWeatherForecast(string query)
        {
            return await sendRequest.GetAsync<ApiWheatherForecastResultModel>(query);
        }

        public async Task<ApiWheatherResultModel> QueryWeather(string latitude, string longitude)
        {
            return await sendRequest.GetAsync<ApiWheatherResultModel>(string.Format(ApiWheatherUrl, latitude, longitude));
        }
    }
}
