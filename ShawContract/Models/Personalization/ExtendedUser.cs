using System.Collections.Generic;
using CMS.Membership;

using Kentico.Membership;
using Newtonsoft.Json;

namespace ShawContract.Models.Personalization
{
    // Extends the default Kentico.Membership.User object
    public class ExtendedUser : User
    {
        public string CellPhone { get; set; }

        // Property that corresponds to a custom field specified in the administration interface
        public string CompanyName
        {
            get; set;
        }

        public string Industry
        {
            get;
            set;
        }

        public string JobTitle
        {
            get; set;
        }

        public string Language
        {
            get; set;
        }

        public string Segments
        {
            get; set;
        }

        public string ShippingAddresses
        {
            get; set;
        }

        public IList<Address> ShippingAddressesList
        {
            get
            {
                List<Address> addresses = new List<Address>();
                if (string.IsNullOrEmpty(this.ShippingAddresses) == false)
                {
                    addresses = JsonConvert.DeserializeObject<List<Address>>(this.ShippingAddresses);
                }
                return addresses;
            }
            set
            {
                this.ShippingAddresses = ShippingAddresses = JsonConvert.SerializeObject(value);
            }
        }

        public string Title { get; set; }

        public string WorkPhone
        {
            get; set;
        }

        public string WorkPhoneExtension
        {
            get; set;
        }

        //// Exposes the existing 'MiddleName' property of the 'UserInfo' object
        //public string MiddleName
        //{
        //    get;
        //    set;
        //}

        // Ensures field mapping between Kentico's user objects and the Kentico.Membership ASP.NET Identity implementation
        // Called when retrieving users from Kentico via Kentico.Membership.KenticoUserManager<TUser>
        public override void MapFromUserInfo(UserInfo source)
        {
            // Calls the base class implementation of the MapFromUserInfo method
            base.MapFromUserInfo(source);

            //// Maps the 'MiddleName' property to the extended user object
            //MiddleName = source.MiddleName;

            // Sets the value of the 'CustomField' property
            CompanyName = source.GetValue<string>("CompanyName", null);
            Industry = source.GetValue<string>("Industry", null);
            JobTitle = source.GetValue<string>("JobTitle", null);
            ShippingAddresses = source.GetValue<string>("ShippingAddresses", null);
            WorkPhone = source.GetValue<string>("WorkPhone", null);
            WorkPhoneExtension = source.GetValue<string>("WorkPhoneExtension", null);
            CellPhone = source.GetValue<string>("CellPhone", null);
            Segments = source.GetValue<string>("Segments", null);
            Language = source.GetValue<string>("Language", null);
            Title = source.GetValue<string>("Title", null);
        }

        // Ensures field mapping between Kentico's user objects and the Kentico.Membership ASP.NET Identity implementation
        // Called when creating or updating users using Kentico.Membership.KenticoUserManager<TUser>
        public override void MapToUserInfo(UserInfo target)
        {
            // Calls the base class implementation of the MapToUserInfo method
            base.MapToUserInfo(target);

            //// Maps the 'MiddleName' property to the target 'UserInfo' object
            //target.MiddleName = MiddleName;

            // Sets the value of the 'CustomField' custom user field
            target.SetValue("CompanyName", CompanyName);
            target.SetValue("Industry", Industry);
            target.SetValue("JobTitle", JobTitle);
            target.SetValue("ShippingAddresses", ShippingAddresses);
            target.SetValue("WorkPhone", WorkPhone);
            target.SetValue("WorkPhoneExtension", WorkPhoneExtension);
            target.SetValue("CellPhone", CellPhone);
            target.SetValue("Segments", Segments);
            target.SetValue("Language", Language);
            target.SetValue("Title", Title);
        }
    }
}