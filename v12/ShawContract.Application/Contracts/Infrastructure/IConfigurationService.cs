namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface IConfigurationService
    {
        string GetAppSetting(string key);
    }
}