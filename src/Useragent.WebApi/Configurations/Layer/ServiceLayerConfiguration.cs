using DeviceDetectorNET.Parser.Device;
using Useragent.DataAccess.IRepositories;
using Useragent.DataAccess.Repositories;
using Useragent.Service.Interfaces;
using Useragent.Service.Interfacesk;
using Useragent.Service.Services;

namespace Useragent.WebApi.Configurations.Layer;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserAgentService, UserAgentService>();
        builder.Services.AddScoped<IGeoInfoProvider, GeoInfoProvider>();
        //--------------------------
        builder.Services.AddScoped<IUserAgent, UserAgentRepository>();
    }
}
