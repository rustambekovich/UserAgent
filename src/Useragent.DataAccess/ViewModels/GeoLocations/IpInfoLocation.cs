namespace Useragent.DataAccess.ViewModels.GeoLocations;

public class IpInfoLocation
{
    public int GeonameId { get; set; }
    public string Capital { get; set; }
    public List<Language> Languages { get; set; }
    public string CountryFlag { get; set; }
    public string CountryFlagEmoji { get; set; }
    public string CountryFlagEmojiUnicode { get; set; }
    public string CallingCode { get; set; }
    public bool IsEU { get; set; }
}
