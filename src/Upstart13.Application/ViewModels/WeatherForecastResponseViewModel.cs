namespace Upstart13.Application.ViewModels
{
    public class WeatherForecastResponseViewModel
    {
        public IEnumerable<PeriodModel> Periods { get; set; }
    }
    public class PeriodModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string IsDaytime { get; set; }
        public string Temperature { get; set; }
        public string TemperatureUnit { get; set; }
        public string TemperatureTrend { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }
        public string Icon { get; set; }
        public string ShortForecast { get; set; }
        public string DetailedForecast { get; set; }
    }
}
