using Upstart13.Infrastructure.ExternalCommunication.CommunicationModels;

namespace Upstart13.Infrastructure.ExternalCommunication.Interfaces
{
    public interface IWeatherService
    {
        Task<GeocodingResultModel> QueryGeocodding(string query);
        Task<ApiWheatherResultModel> QueryWeather(string latitude, string longitude);
        Task<ApiWheatherForecastResultModel> QueryWeatherForecast(string query);
    }
}
