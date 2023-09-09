namespace Useragent.Service.Interfacesk;

public interface IUserAgent
{
    public Task<bool> CreateAsync(string dto, string ip);
}
