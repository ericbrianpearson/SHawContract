using CMS.CustomTables;
using CMS.DataEngine;
using CMS.Globalization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShawContract.Infrastructure
{

    public class CmsDataHelper
    {
        public static IDictionary<string, string> GetCountriesList()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            var countries = CountryInfoProvider.GetCountries();
            foreach (var cntry in countries)
            {
                dict.Add(cntry.CountryTwoLetterCode, cntry.CountryDisplayName);
            }
            return dict;
        }

        public static IDictionary<string, string> GetIndustries()
        {
            string customTableClassName = "ShawContract.Industries";
            IDictionary<string, string> dict = GetLookupValuesFromCustomTable(customTableClassName);

            return dict;
        }

        public static IDictionary<string, string> GetJobTitles()
        {
            string customTableClassName = "ShawContract.JobTitles";
            IDictionary<string, string> dict = GetLookupValuesFromCustomTable(customTableClassName);

            return dict;
        }

        public static IDictionary<string, string> GetLanguages()
        {
            string customTableClassName = "ShawContract.Languages";
            IDictionary<string, string> dict = GetLookupValuesFromCustomTable(customTableClassName);

            return dict;
        }

        public static IDictionary<string, string> GetSegments()
        {
            string customTableClassName = "ShawContract.Segments";
            IDictionary<string, string> dict = GetLookupValuesFromCustomTable(customTableClassName);

            return dict;
        }

        public static IDictionary<string, string> GetStatesList()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            var countries = CountryInfoProvider.GetCountriesWithStates();
            foreach (var cntry in countries)
            {
                var states = StateInfoProvider.GetStates().WhereEquals("CountryID", cntry.CountryID);
                foreach (var state in states)
                {
                    dict.Add(state.StateCode, state.StateDisplayName);
                }
            }
            return dict;
        }

        public static IDictionary<string, string> GetTitles()
        {
            string customTableClassName = "ShawContract.Titles";
            IDictionary<string, string> dict = GetLookupValuesFromCustomTable(customTableClassName);

            return dict;
        }

        public static IDictionary<string, string> GetLookupValuesFromCustomTable(string customTableClassName)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
            if (customTable != null)
            {
                var items = CustomTableItemProvider.GetItems(customTableClassName);
                foreach (var item in items)
                {
                    dict.Add((string)item["Key"], (string)item["Value"]);
                }
            }

            return dict;
        }

        public static IDictionary<string, string> GetSettingsValuesFromCustomTable(string customTableClassName)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            DataClassInfo customTable = DataClassInfoProvider.GetDataClassInfo(customTableClassName);
            if (customTable != null)
            {
                var items = CustomTableItemProvider.GetItems(customTableClassName);
                foreach (var item in items)
                {
                    dict.Add((string)item["Key"], (string)item["Value"]);
                }
            }

            return dict;
        }

        public static string GetSetting(string key)
        {
            string customTableClassName = "ShawContract.Settings";
            IDictionary<string, string> dict = GetLookupValuesFromCustomTable(customTableClassName);

            return dict[key];
        }
    }
}
