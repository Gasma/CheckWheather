using FluentValidation;
using Upstart13.Application.Queries.WeatherForecast;

namespace Upstart13.Application.Validations
{
    public class WeatherForecastQueryValidator : AbstractValidator<WeatherForecastQuery>
    {
        public WeatherForecastQueryValidator()
        {
            RuleFor(a => a.Street)
                .NotEmpty()
                .WithMessage("Street is required")
                .MaximumLength(200)
                .WithMessage("The Street max length is 200 characters");

            RuleFor(a => a.City)
                .NotEmpty()
                .WithMessage("City is required")
                .MaximumLength(200)
                .WithMessage("The City max length is 200 characters");

            When(t => string.IsNullOrEmpty(t.State), () =>
            {
                RuleFor(t => t.Zip)
                    .NotEmpty()
                    .WithMessage("Specify street with city and state or zip");
            });
        }
    }
}
