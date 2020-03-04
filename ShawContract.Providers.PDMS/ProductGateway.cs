using Newtonsoft.Json;
using ShawContract.Providers.PDMS.Interfaces;
using ShawContract.Providers.PDMS.Models;
using ShawContract.Providers.PDMS.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShawContract.Providers.PDMS
{
    public class ProductGateway
    {
        private HttpClient HttpClient { get; }
        private IPDMSConfiguration PDMSConfiguration { get; }

        public ProductGateway(IPDMSConfiguration pdmsConfiguration)
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.Timeout = new System.TimeSpan(0, 15, 0);
            this.PDMSConfiguration = pdmsConfiguration;
        }

        //TODO: Change when PDMS team is ready
        public async Task<IEnumerable<T>> GetProductSpecificationsAsync<T>(string productType) where T : class
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();

            switch (productType)
            {
                case "Carpet":
                    httpResponse = await this.HttpClient.GetAsync(string.Format("{0}?uid={1}&$filter=(SellingStyleNumber in ( '5A259', '5T339','800X1', '5T175') )", this.PDMSConfiguration.PDMSApiUrl, this.PDMSConfiguration.PDMSUid)).ConfigureAwait(false);
                    break;

                case "Rug":
                    httpResponse = await this.HttpClient.GetAsync(string.Format("{0}?uid={1}&$filter=(SellingStyleNumber in ( '5A262', 'G021R', 'G022R') )", this.PDMSConfiguration.PDMSApiUrl, this.PDMSConfiguration.PDMSUid)).ConfigureAwait(false);
                    break;

                case "Resilient":
                    httpResponse = await this.HttpClient.GetAsync(string.Format("{0}?uid={1}&$filter=(SellingStyleNumber in ( '0993V', '0922V') )", this.PDMSConfiguration.PDMSApiUrl, this.PDMSConfiguration.PDMSUid)).ConfigureAwait(false);
                    break;

                case "Hardwood":
                    httpResponse = await this.HttpClient.GetAsync(string.Format("{0}?uid={1}&$filter=(SellingStyleNumber in ( 'CA334') )", this.PDMSConfiguration.PDMSApiUrl, this.PDMSConfiguration.PDMSUid)).ConfigureAwait(false);
                    break;

                default:
                    break;
            }

            //  httpResponse = await this.HttpClient.GetAsync(string.Format("{0}?$filter=(InventoryType%20eq%20%27{1}%27%20)&uid={2}", this.PDMSConfiguration.PDMSApiUrl, productType, this.PDMSConfiguration.PDMSUid)).ConfigureAwait(false);

            httpResponse.EnsureSuccessStatusCode();

            var content = await httpResponse.Content.ReadAsStringAsync();

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content, jsonSettings);
        }

        public async Task<T> GetSingleProductSpecificationsAsync<T>(string styleNumber) where T : class
        {
            HttpResponseMessage httpResponse = await this.HttpClient.GetAsync(string.Format("{0}/{1}?uid={2}", this.PDMSConfiguration.PDMSApiUrl, styleNumber, this.PDMSConfiguration.PDMSUid)).ConfigureAwait(false);

            httpResponse.EnsureSuccessStatusCode();

            var content = await httpResponse.Content.ReadAsStringAsync();

            var jsonSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.DeserializeObject<IEnumerable<T>>(content, jsonSettings).FirstOrDefault();
        }
    }
}