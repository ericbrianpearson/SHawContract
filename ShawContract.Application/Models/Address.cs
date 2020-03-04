using System;

namespace ShawContract.Application.Models
{
    public class Address
    {
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string CountryName { get; set; }
        public string StateCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public Guid GUID { get; set; }
        public DateTime LastModified { get; set; }
    }
}