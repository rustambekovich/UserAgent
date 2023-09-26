using Newtonsoft.Json;
using System.Runtime;
using Useragent.DataAccess.ViewModels.GeoLocations;
using Useragent.Service.Interfaces;

namespace Useragent.Service.Services;

public class GeoInfoProvider : IGeoInfoProvider
{
    private readonly HttpClient _httpClient;
    //create constructor and call HttpClient
    public GeoInfoProvider()
    {
        _httpClient = new HttpClient()
        {
            Timeout = TimeSpan.FromSeconds(5)
        };
    }

    public async Task<IpInfoViewModel> GetGeoInfo(string ip)
    {
        var ipAddress = ip;
        var response = await _httpClient.GetAsync($"http://api.ipstack.com/" 
            + ipAddress + "?access_key=84dbd3278e624e0f8b9416ca87f0754f");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var model = new GeoInfoViewModel();
            IpInfoViewModel ipInfo = JsonConvert.DeserializeObject<IpInfoViewModel>(json)!;
            model = JsonConvert.DeserializeObject<GeoInfoViewModel>(json);
            prin(ipInfo);   
            return ipInfo;
        }
        return null;
    }

    public  void prin(IpInfoViewModel ipInfo)
    {
        /*Console.WriteLine("IP: " + ipInfo.Ip);
        Console.WriteLine("Type: " + ipInfo.Type);
        Console.WriteLine("Continent: " + ipInfo.ContinentName);
        Console.WriteLine("Country: " + ipInfo.CountryName);
        Console.WriteLine("Region: " + ipInfo.RegionName);
        Console.WriteLine("City: " + ipInfo.City);
        Console.WriteLine("Zip Code: " + ipInfo.Zip);
        Console.WriteLine("Latitude: " + ipInfo.Latitude);
        Console.WriteLine("Longitude: " + ipInfo.Longitude);
        Console.WriteLine("Capital: " + ipInfo.Location.Capital);
        Console.WriteLine("Languages:");
        foreach (var language in ipInfo.Location.Languages)
        {
            Console.WriteLine(language.Name + " - " + language.Native);
        }
        Console.WriteLine("Country Flag: " + ipInfo.Location.CountryFlag);
        Console.WriteLine("Calling Code: " + ipInfo.Location.CallingCode);
        Console.WriteLine("EU Member: " + (ipInfo.Location.IsEU ? "Yes" : "No"));*/

    }
}
