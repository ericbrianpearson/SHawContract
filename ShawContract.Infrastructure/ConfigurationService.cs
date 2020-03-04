using System;
using System.Collections.Generic;
using ShawContract.Application.Contracts.Infrastructure;

namespace ShawContract.Infrastructure
{
    public class ConfigurationService : IConfigurationService
    {
        public string GetAppSetting(string key)
        {
            string settingValue = string.Empty;
            try
            {
                IDictionary<string, string> dict = CmsDataHelper.GetSettingsValuesFromCustomTable("ShawContract.Settings");

                settingValue = dict[key];
            }
            catch (Exception ex)
            {
                settingValue = System.Configuration.ConfigurationManager.AppSettings[key];

                if (string.IsNullOrEmpty(settingValue))
                {
                    throw new ArgumentNullException(String.Format("Value for {0} is not provided. Make sure that '{0}' key is added in the app settings section of app.config.", key));
                }
            }

            return settingValue;
        }
    }
}