using AutoMapper;
using MediatR;
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

        private readonly IWeatherService weatherService;
        private readonly NotificationContext notification;
        private readonly IMapper mapper;

        public WeatherForecastQueryHandler(IWeatherService _weatherService,
            IMapper _mapper,
            NotificationContext _notification)
        {
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

            var convertedAddress = await weatherService.QueryGeocodding(request.GetUrl());
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

            return mapper.Map<WeatherForecastResponseViewModel>(weatherForecast);
        }
    }
}
