namespace Useragent.Domain;

public class UserAgent
{
    public long Id { get; set; }
    public string OperationSystem { get; set; } = string.Empty;
    public string OperationSystemType { get; set; } = string.Empty;
    public string VersionOs { get; set; } = string.Empty;
    public string Device { get; set; } = string.Empty;
    public string DeviceCompany { get; set; } = string.Empty;
    public string DeviceName { get; set; } = string.Empty;
    public string PublicIp { get; set; } = string.Empty;
    public string IsBrowser { get; set; } = string.Empty;
    public string Browser { get; set; } = string.Empty;
    public string BrowserMode { get; set; } = string.Empty;
    public string BrowserVersion { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public double AddressLatitude { get; set; }
    public double AddressLongitude { get; set; }
    public string WebCamera { get; set; } = string.Empty;
    public string FileLocations { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set;}


}
