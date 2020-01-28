using System.Configuration;
using ShawContract.Providers.PDMS.Config;
using ShawContract.Providers.PDMS.Interfaces;

namespace ShawContract.Providers.PDMS
{
    public class PDMSConfiguration : IPDMSConfiguration
    {
        public string PDMSApiUrl => "https://specifications.shawinc.com/api/v1/Specifications";
        //"ConfigurationManager.GetAppSetting(ConfigurationKeys.PDMSApiUrl)";

        public string PDMSUid => "EFD2FA0A-269D-4FFA-8648-72DDF81CCEA5";
        //"ConfigurationManager.GetAppSetting(ConfigurationKeys.PDMSUid)";
    }
}