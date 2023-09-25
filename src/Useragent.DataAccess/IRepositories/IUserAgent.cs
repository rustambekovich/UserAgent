using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Useragent.Domain;

namespace Useragent.DataAccess.IRepositories
{
    public interface IUserAgent
    {
        public Task<string> GetUserAgent();
        public Task<string> GetUserAgentAsync();
        public Task<long> CrestUserAgentAsync(UserAgent userAgent); 
    }
}
