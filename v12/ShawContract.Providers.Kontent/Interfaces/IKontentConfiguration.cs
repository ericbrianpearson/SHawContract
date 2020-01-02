namespace ShawContract.Providers.Kontent.Interfaces
{
    public interface IKontentConfiguration
    {
        string Key { get; }
        string KontentApiUrl { get; }
        string ProjectId { get; }
    }
}