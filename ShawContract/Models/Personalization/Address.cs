using System;

namespace ShawContract.Models.Personalization
{
    public class Address
    {
        public Guid Id { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public bool IsDefault { get; set; }

        public string PostalCode { get; set; }

        public string SmsAlertNumber { get; set; }

        public string State { get; set; }

        public string Province { get; set; }

        public string StreetLine1 { get; set; }

        public string StreetLine2 { get; set; }

        public string Title { get; set; }
    }
}