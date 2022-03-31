using AutoMapper;
using Upstart13.Application.ViewModels;
using Upstart13.Infrastructure.ExternalCommunication.CommunicationModels;

namespace Upstart13.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApiWheatherForecastResultModel, WeatherForecastResponseViewModel>()
                .ForMember(a => a.Periods, opt => opt.MapFrom(src => src.Properties.Periods));
        }
    }
}
