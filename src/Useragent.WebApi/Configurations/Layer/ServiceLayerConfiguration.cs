using Useragent.Service.Interfacesk;
using Useragent.Service.Services;

namespace Useragent.WebApi.Configurations.Layer;

public static class ServiceLayerConfiguration
{
    public static void ConfigureServiceLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUserAgent, UserAgent>();
    }
}
