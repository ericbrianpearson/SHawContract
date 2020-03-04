using System;
using ShawContract.Application.Constants;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Infrastructure;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML;
using Twilio.Types;

namespace ShawContract.Application.Services
{
    public class TwilioClientService : ITwilioClientService
    {
        public IConfigurationService ConfigurationService { get; }

        public TwilioClientService(IConfigurationService configurationService)
        {
            ConfigurationService = configurationService;
            InitilizeTwilio();
        }

        public void InitilizeTwilio()
        {
            TwilioClient.Init(CmsDataHelper.GetSetting(ConfigurationKeys.TwilioAccountSID),
                              CmsDataHelper.GetSetting(ConfigurationKeys.TwilioAuthToken));
        }

        public void Call(string callNumber)
        {
            var twilioPhone = new PhoneNumber(ConfigurationService.GetAppSetting(ConfigurationKeys.TwilioPhone));
            var supportPhone = ConfigurationService.GetAppSetting(ConfigurationKeys.CustomerSupportNumber);
            var instructions = $"<Response><Say voice=\"alice\">I am now connecting you to Shaw Contract customer service.</Say><Dial>{supportPhone}</Dial></Response>";
            var call = CallResource.Create(new PhoneNumber(callNumber), twilioPhone, twiml: instructions);
        }

        public TwiML ConstructVoiceResponse()
        {
            var supportPhone = ConfigurationService.GetAppSetting(ConfigurationKeys.CustomerSupportNumber);
            var response = new VoiceResponse();
            response.Say("I am now connecting you to Shaw Contract customer service.")
                .Dial(supportPhone)
                .Hangup();

            return response;
        }

        public TwiML ConstructMessageResponse()
        {
            //TODO implement messaging if necessary
            throw new NotImplementedException();
        }
    }
}