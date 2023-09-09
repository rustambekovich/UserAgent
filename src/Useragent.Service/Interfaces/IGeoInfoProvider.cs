namespace Useragent.Service.Interfaces;

public interface IGeoInfoProvider
{
    public  Task<string> GetGeoInfo();
}
