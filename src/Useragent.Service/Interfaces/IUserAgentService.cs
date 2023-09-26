namespace Useragent.Service.Interfacesk;

public interface IUserAgentService
{
    public Task<bool> CreateAsync(string dto, string ip);
}
