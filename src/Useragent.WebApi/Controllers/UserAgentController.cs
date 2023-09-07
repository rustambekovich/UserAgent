using Microsoft.AspNetCore.Mvc;
using Useragent.Service.Interfacesk;

namespace Useragent.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAgentController : ControllerBase
{
    private readonly ILogger<UserAgentController> _logger;
    private readonly IUserAgent _serviceUser;

    public UserAgentController(IUserAgent userService,
        ILogger<UserAgentController> logger)
    {
        _logger = logger;
        this._serviceUser = userService;
    }

    [HttpGet]
    public async Task<IActionResult> CreateAsync()
    {
        string userAgent = Request.Headers["User-Agent"]!;

        return Ok(await _serviceUser.CreateAsync(userAgent));
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
}
