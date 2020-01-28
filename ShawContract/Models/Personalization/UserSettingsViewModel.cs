using System.Collections.Generic;

namespace ShawContract.Models.Personalization
{
    public class UserSettingsViewModel : IViewModel
    {
        public IEnumerable<string> Industries = new List<string>() { "Industry1.", "Industry2" };
        public IEnumerable<string> JobTitles = new List<string>() { "JobTitle1", "JobTitle2" };
        public IEnumerable<string> Languages = new List<string>() { "En", "Fr", "Es" };
        public IEnumerable<string> SegmentsOptions = new List<string>() { "Segment1", "Segment2" };
        public IEnumerable<string> Titles = new List<string>() { "Mr.", "Mrs." };
        public IList<Address> Addresses { get; set; }

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
