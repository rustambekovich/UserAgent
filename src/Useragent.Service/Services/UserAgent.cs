using Useragent.Service.Interfacesk;

namespace Useragent.Service.Services;

public class UserAgent : IUserAgent
{
    public Task<bool> CreateAsync(string dto)
    {

        List<string> lst = new List<string>();
        var uaParser = UAParser.Parser.GetDefault();
        var clientInfo = uaParser.Parse(dto);

        // Extracting the information you mentioned
        string operatingSystem = clientInfo.OS.Family;
        lst.Add(operatingSystem);
        string operatingSystemType = clientInfo.Device.Family;
        lst.Add(operatingSystemType);
        string version = clientInfo.OS.Major;
        lst.Add(version);
        string device = clientInfo.Device.Family;
        lst.Add(device);
        string deviceCompany = clientInfo.Device.Brand;
        lst.Add(deviceCompany);
        string deviceName = clientInfo.Device.Model;
        lst.Add(deviceName);
        string isBrowser = clientInfo.UserAgent.Family;
        lst.Add(isBrowser);
        string browser = clientInfo.UserAgent.Family;
        lst.Add(browser);
        string browserVersion = clientInfo.UserAgent.Major;
        lst.Add(browserVersion);
        Console.Clear();
        var majorVersion = clientInfo.OS.Major; // Major version
        var minorVersion = clientInfo.OS.Minor; // Minor version
        Console.WriteLine($"{majorVersion}.{minorVersion}");
        Console.WriteLine("1. operatingSystem: " + operatingSystem);
        Console.WriteLine("2. operatingSystemType: " + operatingSystemType);
        Console.WriteLine("3. version: " + version);
        Console.WriteLine("4. device: " + device);
        Console.WriteLine("5. deviceCompany: " + deviceCompany);
        Console.WriteLine("6. deviceName: " + deviceName);
        Console.WriteLine("7. publicIp: " + "publicIp");
        Console.WriteLine("8. isBrowser: " + isBrowser);
        Console.WriteLine("9. browser: " + browser);
        Console.WriteLine("10. browserVersion: " + browserVersion);

        return Task.FromResult(true);
    }
}
