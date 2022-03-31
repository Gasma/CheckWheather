namespace Upstart13.Infrastructure.ExternalCommunication.CommunicationModels
{
    public class ApiWheatherResultModel
    {
        public PropertiesModel Properties { get; set; }
    }
    public class PropertiesModel
    {
        public string ForecastOffice { get; set; }
        public string GridId { get; set; }
        public string GridX { get; set; }
        public string GridY { get; set; }
        public string Forecast { get; set; }
        public string ForecastHourly { get; set; }
        public string ForecastGridData { get; set; }
        public string ObservationStations { get; set; }
        public string ForecastZone { get; set; }
        public string County { get; set; }
        public string FireWeatherZone { get; set; }
        public string TimeZone { get; set; }
        public string RadarStation { get; set; }
    }
}
