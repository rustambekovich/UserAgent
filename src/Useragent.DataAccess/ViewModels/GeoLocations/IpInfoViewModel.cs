namespace Useragent.DataAccess.ViewModels.GeoLocations;

public class IpInfoViewModel
{
    public string Ip { get; set; }
    public string Type { get; set; }
    public string ContinentCode { get; set; }
    public string ContinentName { get; set; }
    public string CountryCode { get; set; }
    public string Country_name { get; set; }
    public string RegionCode { get; set; }
    public string Region_name { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public IpInfoLocation Location { get; set; }
}
