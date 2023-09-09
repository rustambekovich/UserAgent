namespace Useragent.Service.Interfaces;

public interface IGeoIPService
{
    public (string Country, string Region) GetCountryAndRegion(string ipAddress);
}
