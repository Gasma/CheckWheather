using Upstart13.Infrastructure.ExternalCommunication.CommunicationModels;

namespace Upstart13.Infrastructure.ExternalCommunication.Interfaces
{
    public interface IWeatherService
    {
        Task<GeocodingResultModel> QueryGeocodding(string query);
        Task<ApiWheatherResultModel> QueryWeather(string query);
        Task<ApiWheatherForecastResultModel> QueryWeatherForecast(string query);
    }
}
