namespace Useragent.DataAccess.ViewModels.GeoLocations;

public class GeoInfoViewModel
{
    public string CountryCode { get; set; } = string.Empty;

    public string CountryName { get; set; } = string.Empty;

    public string RegionCode { get; set; } = string.Empty;

    public string RegionName { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;


    public string ZipCode { get; set; } = string.Empty;

    public float Latitude { get; set; }

    public float Longitude { get; set; }

}