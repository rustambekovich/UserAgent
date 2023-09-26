using DeviceDetectorNET;
using System.Net;
using Useragent.DataAccess.IRepositories;
using Useragent.Service.Interfaces;
using Useragent.Service.Interfacesk;

namespace Useragent.Service.Services;

public class UserAgentService : IUserAgentService
{
    private IGeoInfoProvider _inforservice;
    private IUserAgent _service;

    public UserAgentService(IUserAgent userAgent, IGeoInfoProvider infoProvider)
    {
        this._inforservice = infoProvider;
        this._service = userAgent;
    }
    public async Task<bool> CreateAsync(string dto, string ip)
    {
        Domain.UserAgent userAgent_personals = new Domain.UserAgent();

        var uaParser = UAParser.Parser.GetDefault();
        var clientInfo = uaParser.Parse(dto);

        var infocnt = await _inforservice.GetGeoInfo(ip);

        userAgent_personals.AddressLatitude = infocnt.Latitude;
        userAgent_personals.AddressLongitude = infocnt.Longitude;
        userAgent_personals.County = infocnt.Country_name;
        userAgent_personals.Region = infocnt.Region_name;
        userAgent_personals.PublicIp = ip + "-" + infocnt.Type; 


        userAgent_personals.OperationSystem = clientInfo.OS.Family;
        //userAgent_persenal.OperationSystemType = clientInfo.Device.Family;
        userAgent_personals.VersionOs = clientInfo.OS.Major;
        userAgent_personals.Device = clientInfo.Device.Family;
        userAgent_personals.DeviceCompany = clientInfo.Device.Brand;
        userAgent_personals.DeviceName = clientInfo.Device.Model;
        userAgent_personals.IsBrowser = clientInfo.UserAgent.Family;
        userAgent_personals.Browser = clientInfo.UserAgent.Family;
        userAgent_personals.BrowserVersion = clientInfo.UserAgent.Major;
        userAgent_personals.CreatedAt = userAgent_personals.UpdatedAt = DateTime.UtcNow;

        var dd = new DeviceDetector(dto);
        dd.Parse();

        string deviceName = dd.GetDeviceName();
        string deviceBrand = dd.GetBrandName();
        userAgent_personals.DeviceName = deviceName;
        userAgent_personals.DeviceCompany = deviceBrand;

        string hostname = Dns.GetHostName();
        if(userAgent_personals.Device.ToString() == "Other")
        {
            userAgent_personals.Device = hostname;
        }

        var result = await _service.CrestUserAgentAsync(userAgent_personals);
        if (result > 0)
        {
            return true;
        }

        return false;
    }
}
