using Useragent.DataAccess.ViewModels.GeoLocations;

namespace Useragent.Service.Interfaces;

public interface IGeoInfoProvider
{
    public  Task<IpInfoViewModel> GetGeoInfo(string ip);
}
