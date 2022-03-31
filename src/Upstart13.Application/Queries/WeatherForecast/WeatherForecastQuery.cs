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
            result += string.IsNullOrEmpty(City) ? $"&city={City.Replace(" ", "+").Replace(",", "%2C")}" : string.Empty;
            result += string.IsNullOrEmpty(State) ? $"&state={State.Replace(" ", "+").Replace(",", "%2C")}" : string.Empty;
            result += string.IsNullOrEmpty(Zip) ? $"&zip={Zip.Replace(" ", "+").Replace(",", "%2C")}" : string.Empty;
            return result;
        }
    }
}
