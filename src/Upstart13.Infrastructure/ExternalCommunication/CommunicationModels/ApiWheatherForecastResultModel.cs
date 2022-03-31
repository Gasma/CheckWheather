namespace Upstart13.Infrastructure.ExternalCommunication.CommunicationModels
{
    public class ApiWheatherForecastResultModel
    {
        public ForecastPropertiesModel Properties { get; set; }
    }
    public class ForecastPropertiesModel
    {
        public string Updated { get; set; }
        public string Units { get; set; }
        public string ForecastGenerator { get; set; }
        public string GeneratedAt { get; set; }
        public string UpdateTime { get; set; }
        public string ValidTimes { get; set; }
        public ElevationModel Elevation { get; set; }
        public IEnumerable<PeriodModel> Periods { get; set; }
    }
    public class ElevationModel
    {
        public string UnitCode { get; set; }
        public double Value { get; set; }
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
