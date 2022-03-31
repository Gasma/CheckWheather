namespace Upstart13.Infrastructure.ExternalCommunication.CommunicationModels
{
    public class GeocodingResultModel
    {
        public ResultModel Result { get; set; }
    }
    public class ResultModel
    {
        public InputModel Input { get; set; }
        public IEnumerable<AddressMatchesModel> AddressMatches { get; set; }
    }
    public class InputModel
    {
        public BenchmarkModel Benchmark { get; set; }
        public AddressModel Address { get; set; }

    }
    public class BenchmarkModel
    {
        public int Id { get; set; }
        public string BenchmarkName { get; set; }
        public bool isDefault { get; set; }

    }
    public class AddressModel
    {
        public string Address { get; set; }
    }
    public class AddressMatchesModel
    {
        public string MatchedAddress { get; set; }
        public CoordinatesModel Coordinates { get; set; }
        public TigerLineModel TigerLine { get; set; }
    }
    public class CoordinatesModel
    {
        public string X { get; set; }
        public string Y { get; set; }
    }
    public class TigerLineModel
    {
        public string TigerLineId { get; set; }
        public string Side { get; set; }
    }
    public class AddressComponentsModel
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string PreQualifier { get; set; }
        public string PreDirection { get; set; }
        public string PreType { get; set; }
        public string StreetName { get; set; }
        public string SuffixType { get; set; }
        public string SuffixDirection { get; set; }
        public string SuffixQualifier { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }
}
