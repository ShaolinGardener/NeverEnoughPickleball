namespace NEP.Models
{
    public class GoogleMapModels
    {
    }

    public class GoogleGeocodeResponse
    {
        public List<GoogleGeocodeResult> Results { get; set; }
    }

    public class GoogleGeocodeResult
    {
        public List<GoogleAddressComponent> AddressComponents { get; set; }
        public GoogleGeometry Geometry { get; set; }
    }

    public class GoogleAddressComponent
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public List<string> Types { get; set; }
    }

    public class GoogleGeometry
    {
        public GoogleLocation Location { get; set; }
    }

    public class GoogleLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
