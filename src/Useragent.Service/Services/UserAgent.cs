using Useragent.Service.Interfacesk;

namespace Useragent.Service.Services;

public class UserAgent : IUserAgent
{
    public Task<bool> CreateAsync(string dto, string ip)
    {

        var uaParser = UAParser.Parser.GetDefault();
        var clientInfo = uaParser.Parse(dto);

        // Extracting the information you mentioned
        string operatingSystem = clientInfo.OS.Family;
        string operatingSystemType = clientInfo.Device.Family;
        string version = clientInfo.OS.Major;
        string device = clientInfo.Device.Family;
        string deviceCompany = clientInfo.Device.Brand;
        string deviceName = clientInfo.Device.Model;

        string isBrowser = clientInfo.UserAgent.Family;
        string browser = clientInfo.UserAgent.Family;
        string browserVersion = clientInfo.UserAgent.Major;

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
        Console.WriteLine("7. publicIp: " + ip);
        Console.WriteLine("8. isBrowser: " + isBrowser);
        Console.WriteLine("9. browser: " + browser);
        Console.WriteLine("10. browserVersion: " + browserVersion);

        return Task.FromResult(true);
    }
}
