using Microsoft.AspNetCore.Mvc;
using Useragent.Service.Interfaces;
using Useragent.Service.Interfacesk;

namespace Useragent.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAgentController : ControllerBase
{
    private readonly IGeoInfoProvider _location;
    private readonly ILogger<UserAgentController> _logger;
    private readonly IUserAgentService _serviceUser;
    public string ClientIPAddr { get; private set; }

    public UserAgentController(IUserAgentService userService,
        ILogger<UserAgentController> logger,
        IGeoInfoProvider geoInfoProvider)
    {
        this._location = geoInfoProvider;
        _logger = logger;
        this._serviceUser = userService;
    }

   /* [HttpGet("get/ip")]
    public IActionResult GetIp()
    {
        string remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
        return Ok($"Mijozning IP manzili: {remoteIpAddress}");
    }*/

    [HttpPost("get/location")]
    public async Task<IActionResult> GetLocationAsync([FromForm] string ip)
    {
        var result = await _location.GetGeoInfo(ip);
        
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] string ip)
    {
        string userAgent = Request.Headers["User-Agent"]!;
        string ipAddress = ip;//HttpContext.Connection.RemoteIpAddress.ToString()!;
        return Ok(await _serviceUser.CreateAsync(userAgent, ipAddress));
    }
    /*public IActionResult GetUserAgentInfo()
    {
        string userAgent = Request.Headers["User-Agent"];

        // You can use a library like 'UAParser' to parse the user agent string
        var uaParser = UAParser.Parser.GetDefault();
        var clientInfo = uaParser.Parse(userAgent);

        // Extracting the information you mentioned
        string operatingSystem = clientInfo.OS.Family;
        string operatingSystemType = clientInfo.Device.Family;
        string version = clientInfo.OS.Major;
        string device = clientInfo.Device.Family;
        string deviceCompany = clientInfo.Device.Brand;
        string deviceName = clientInfo.Device.Model;
        string publicIp = HttpContext.Connection.RemoteIpAddress.ToString();
        bool isBrowser = clientInfo.UserAgent.Family != "Other";
        string browser = clientInfo.UserAgent.Family;
        string browserVersion = clientInfo.UserAgent.Major;

        // You can access geolocation information based on the user's IP address using a service or library

        // Create a response object with the user agent information
        var userInfo = new
        {
            OperatingSystem = operatingSystem,
            OperatingSystemType = operatingSystemType,
            Version = version,
            Device = device,
            DeviceCompany = deviceCompany,
            DeviceName = deviceName,
            PublicIp = publicIp,
            IsBrowser = isBrowser,
            Browser = browser,
            BrowserVersion = browserVersion,
            // Add geolocation information as needed
        };

        return Ok(userInfo);
    }
*/
    /*[HttpGet("Ip")]
    public IActionResult GetClientIP()
    {
        // HttpContext orqali IP manzilini olish
        string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

        // Olishgan IP manzilini qaytarish
        return Content(ipAddress);
    }*/
    /*[HttpGet("/device-info")]
    public IActionResult GetDeviceInfo()
    {
        var userAgent = HttpContext.Request.Headers["User-Agent"].ToString();
        var deviceType = "Unknown";

        // User-Agent may contain information about the device
        if (userAgent.Contains("Mobile", StringComparison.OrdinalIgnoreCase))
        {
            deviceType = "Mobile Device";
        }
        else if (userAgent.Contains("Tablet", StringComparison.OrdinalIgnoreCase))
        {
            deviceType = "Tablet Device";
        }
        else if (userAgent.Contains("Windows", StringComparison.OrdinalIgnoreCase))
        {
            deviceType = "Windows PC";
        }
        else if (userAgent.Contains("Macintosh", StringComparison.OrdinalIgnoreCase))
        {
            deviceType = "Macintosh PC";
        }
        // Add more checks based on your requirements

        var result = new
        {
            UserAgent = userAgent,
            DeviceType = deviceType
        };

        return Ok(result);
    }*/
}
