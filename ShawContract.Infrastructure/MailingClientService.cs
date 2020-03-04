using ShawContract.Application.Constants;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Models;

namespace ShawContract.Infrastructure
{
    public class MailingClientService : IMailingClientService
    {
        public MailingClientService(IConfigurationService configurationService)
        {
            this.ConfigurationService = configurationService;
        }

        protected IConfigurationService ConfigurationService { get; }

        public void SendMail(ContactUsEmail emailData)
        {
            string Body = ConfigurationService.GetAppSetting(ConfigurationKeys.Contactus_EmailBody);

            CMS.EmailEngine.EmailMessage emailToSend = new CMS.EmailEngine.EmailMessage();
            emailToSend.From = emailData.Sender;
            emailToSend.Recipients = ConfigurationService.GetAppSetting(ConfigurationKeys.Contactus_EmailRecipient);
            emailToSend.Subject = ConfigurationService.GetAppSetting(ConfigurationKeys.Contactus_EmailSubject);
            emailToSend.Body = string.Format(Body, emailData.FirstName, emailData.LastName, emailData.JobRole, emailData.AssistanceNeeded, emailData.Description); ;

            CMS.EmailEngine.EmailSender.SendEmail("ShawContract", emailToSend);
        }
    }
}
