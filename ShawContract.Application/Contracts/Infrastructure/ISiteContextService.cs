namespace ShawContract.Application.Contracts.Infrastructure
{
    public interface ISiteContextService
    {
        string SiteName { get; }
        string CurrentSiteCulture { get; }
    }
}