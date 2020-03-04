using System.Collections.Generic;
using ShawContract.Infrastructure;
using ShawContract.Utils;

namespace ShawContract.Models.Personalization
{
    public class UserSettingsViewModel : IViewModel
    {
        public IDictionary<string, string> Countries = CmsDataHelper.GetCountriesList();
        public IDictionary<string, string> Industries = CmsDataHelper.GetIndustries();
        public IDictionary<string, string> JobTitles = CmsDataHelper.GetJobTitles();
        public IDictionary<string, string> Languages = CmsDataHelper.GetLanguages();
        public IDictionary<string, string> SegmentsOptions = CmsDataHelper.GetSegments();
        public IDictionary<string, string> States = CmsDataHelper.GetStatesList();
        public IDictionary<string, string> Titles = CmsDataHelper.GetTitles();
        public IList<Address> Addresses { get; set; }

        public Address AddressToEdit { get; set; }

        public string CellPhone { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Industry { get; set; }

        public string JobTitle { get; set; }

        public string Language { get; set; }

        public string LastName { get; set; }

        public IList<string> Segments { get; set; }

        public IList<Address> ShippingAddresses { get; set; }

        public string Title { get; set; }

        public string WorkPhone { get; set; }

        public string WorkPhoneExtension { get; set; }
    }
}
