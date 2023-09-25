using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Useragent.DataAccess.IRepositories;

namespace Useragent.DataAccess.Repositories
{
    public class UserAgent : BaseRepository, IUserAgent
    {
        public async Task<long> CrestUserAgentAsync(Domain.UserAgent userAgent)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.user_agent_info( operation_system, operation_system_type , " +
                    " version_os, device, device_company, device_name, public_ip, is_browser, browser, browser_mode, " +
                    " browser_version, county, region, address_longitude, address_latitude, web_camera, file_locations, " +
                    " created_at, updated_at) VALUES ( @OperationSystem, @OperationSystemType, @VersionOs, @Device, " +
                    " @DeviceCompany, @DeviceName, @PublicIp, @IsBrowser, @Browser, @BrowserMode, @BrowserVersion, @County, " +
                    " @Region, @AddressLongitude, @AddressLatitude,  @WebCamera, @FileLocations, @CreatedAt, @UpdatedAt);";
                var result = await _connection.ExecuteScalarAsync<long>(query, userAgent);

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
}
