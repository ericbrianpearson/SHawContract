namespace ShawContract.Application.Constants
{
    public static class ConfigurationKeys
    {
        public static string KontentApiUrl => "KontentApiUrl";
        public static string KontentProjectId => "KontentProjectId";
        public static string KontentApiKey => "KontentApiKey";

        public static string CachingTimeoutMinutes => "CachingTimeoutMinutes";

        public static string TwilioAccountSID => "TwilioAccountSID";
        public static string TwilioAuthToken => "TwilioAuthToken";
        public static string TwilioPhone => "TwilioPhone";
        public static string CustomerSupportNumber => "CustomerSupportNumber";

        //Email settings
        //public static string Host => "Host";
        public static string Contactus_EmailRecipient => "Contactus_EmailRecipient";
        public static string Contactus_EmailSubject => "Contactus_EmailSubject";
        public static string Contactus_EmailBody => "Contactus_EmailBody";
    }
}