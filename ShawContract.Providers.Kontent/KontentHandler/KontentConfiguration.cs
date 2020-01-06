using ShawContract.Application.Constants;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Providers.Kontent.Interfaces;

namespace ShawContract.Providers.Kontent.KontentHandler
{
    public class KontentConfiguration : IKontentConfiguration
    {
        public string KontentApiUrl => ConfigurationManager.GetAppSetting(ConfigurationKeys.KontentApiUrl);

        public string ProjectId => ConfigurationManager.GetAppSetting(ConfigurationKeys.KontentProjectId);

        public string Key => ConfigurationManager.GetAppSetting(ConfigurationKeys.KontentApiKey);

        private IConfigurationService ConfigurationManager;

        public KontentConfiguration(IConfigurationService configurationManager)
        {
            this.ConfigurationManager = configurationManager;
        }
    }
}