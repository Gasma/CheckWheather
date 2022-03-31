using MediatR;
using Upstart13.Application.ViewModels;

namespace Upstart13.Application.Queries.WeatherForecast
{
    public class WeatherForecastQuery : IRequest<WeatherForecastResponseViewModel>
    {
        public string Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }

        public string GetUrl()
        {
            var result = $"street={Street.Replace(" ", "+").Replace(",", "%2C")}";
            result += string.IsNullOrEmpty(City) ? string.Empty : $"&city={City.Replace(" ", "+").Replace(",", "%2C")}";
            result += string.IsNullOrEmpty(State) ? string.Empty : $"&state={State.Replace(" ", "+").Replace(",", "%2C")}";
            result += string.IsNullOrEmpty(Zip) ? string.Empty : $"&zip={Zip.Replace(" ", "+").Replace(",", "%2C")}";
            return result;
        }
    }
}
