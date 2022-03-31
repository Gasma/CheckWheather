using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Upstart13.Application.Notifications;
using Upstart13.Application.Queries.WeatherForecast;
using Upstart13.Application.Validations;
using Upstart13.Application.ViewModels;
using Upstart13.Infrastructure.ExternalCommunication.Interfaces;

namespace Upstart13.Application.Queries.Handlers
{
    public class WeatherForecastQueryHandler :
        IRequestHandler<WeatherForecastQuery, WeatherForecastResponseViewModel>
    {
        private readonly IMemoryCache cache;
        private readonly IWeatherService weatherService;
        private readonly NotificationContext notification;
        private readonly IMapper mapper;

        public WeatherForecastQueryHandler(IMemoryCache _cache, IWeatherService _weatherService,
            IMapper _mapper, NotificationContext _notification)
        {
            cache = _cache;
            weatherService = _weatherService;
            mapper = _mapper;
            notification = _notification;
        }

        public async Task<WeatherForecastResponseViewModel> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var validationResult = new WeatherForecastQueryValidator().Validate(request);
            if (!validationResult.IsValid)
            {
                notification.AddNotifications(validationResult);
                return null;
            }
            var requestUrl = request.GetUrl();
            var result = (WeatherForecastResponseViewModel)this.cache.Get(requestUrl);
            if (result is null)
            {
                var convertedAddress = await weatherService.QueryGeocodding(requestUrl);
                if (convertedAddress == null ||
                    convertedAddress.Result == null ||
                    convertedAddress.Result.AddressMatches == null ||
                    convertedAddress.Result.AddressMatches.Count() < 0)
                {
                    notification.AddNotification("AddressError", "Address not found!");
                    return null;
                }

                var weatherInfo = await weatherService.QueryWeather(convertedAddress.Result.AddressMatches.FirstOrDefault().Coordinates.Y, convertedAddress.Result.AddressMatches.FirstOrDefault().Coordinates.X);

                if (weatherInfo == null ||
                    weatherInfo.Properties == null ||
                    weatherInfo.Properties.Forecast == null)
                {
                    notification.AddNotification("WeatherError", "Weather not found!");
                    return null;
                }

                var weatherForecast = await weatherService.QueryWeatherForecast(weatherInfo.Properties.Forecast);

                if (weatherForecast == null ||
                    weatherForecast.Properties == null ||
                    weatherForecast.Properties.Periods == null)
                {
                    notification.AddNotification("WeatherForecastError", "Weather Forecast not found!");
                    return null;
                }
                result = mapper.Map<WeatherForecastResponseViewModel>(weatherForecast);
                this.cache.Set(requestUrl, result, TimeSpan.FromMinutes(60));
            }
            return result;
        }
    }
}
