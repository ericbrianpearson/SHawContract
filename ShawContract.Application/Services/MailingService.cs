using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Helpers;
using ShawContract.Application.Models;
using System;

namespace ShawContract.Application.Services
{
    public class MailingService : IMailingService
    {
        private IMailingClientService MailingClient { get; }
        private ILoggingService LoggingService { get; }


        public MailingService(IMailingClientService mailingClient, ILoggingService loggingService)
        {
            this.MailingClient = mailingClient;
            this.LoggingService = loggingService;
        }

        public void SendEmail(ContactUsEmail email)
        {
            try
            {
               Retry.Do(() => MailingClient.SendMail(email), TimeSpan.FromSeconds(2));
            }
            catch (AggregateException ex)
            {
                foreach (var exception in ex.InnerExceptions)
                {
                    LoggingService.Log(LogLevel.Error, exception.Message, exception.StackTrace);
                }
            }
        }
    }
}
