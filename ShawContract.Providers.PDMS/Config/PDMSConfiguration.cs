using System.Configuration;
using ShawContract.Providers.PDMS.Config;
using ShawContract.Providers.PDMS.Interfaces;

namespace ShawContract.Providers.PDMS
{
    public class PDMSConfiguration : IPDMSConfiguration
    {
        public string PDMSApiUrl => ConfigurationManager.AppSettings[ConfigurationKeys.PDMSApiUrl];

        public string PDMSUid => ConfigurationManager.AppSettings[ConfigurationKeys.PDMSUid];
    }
}