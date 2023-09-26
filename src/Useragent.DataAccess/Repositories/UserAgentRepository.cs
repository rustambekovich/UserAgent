using Dapper;
using Useragent.DataAccess.IRepositories;

namespace Useragent.DataAccess.Repositories;

public class UserAgentRepository : BaseRepository, IUserAgent
{
    public async Task<long> CrestUserAgentAsync(Domain.UserAgent userAgent)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.user_agent_info( operation_system," +
                " version_os, device, device_company, device_name, public_ip, is_browser, browser, " +
                " browser_version, county, region, address_longitude, address_latitude, web_camera, file_locations, " +
                " created_at, updated_at) VALUES ( @OperationSystem,  @VersionOs, @Device, " +
                " @DeviceCompany, @DeviceName, @PublicIp, @IsBrowser, @Browser,  @BrowserVersion, @County, " +
                " @Region, @AddressLongitude, @AddressLatitude,  @WebCamera, @FileLocations, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, userAgent);

            return result;
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();

        }
    }

    public Task<string> GetUserAgent()
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserAgentAsync()
    {
        throw new NotImplementedException();
    }
}
