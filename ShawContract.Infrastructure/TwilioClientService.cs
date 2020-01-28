using ShawContract.Application.Constants;
using ShawContract.Application.Contracts.Infrastructure;
using System;
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
            TwilioClient.Init(ConfigurationService.GetAppSetting(ConfigurationKeys.TwilioAccountSID),
                              ConfigurationService.GetAppSetting(ConfigurationKeys.TwilioAuthToken));
        }

        public void Call(string callNumber)
        {
            var to = new PhoneNumber("+359883485714");
            var from = new PhoneNumber(ConfigurationService.GetAppSetting(ConfigurationKeys.TwilioPhone));

            var call = CallResource.Create(to, from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"));
        }

        public TwiML ConstructVoiceResponse()
        {
            //TODO: Possible change the response with something coming from a config file or a dictionary

            var response = new VoiceResponse();
            response.Say("Thank you for using our system. Call during office hours");

            return response;
        }

        public TwiML ConstructMessageResponse()
        {
            //TODO implement messaging if necessary
            throw new NotImplementedException();
        }
    }
}