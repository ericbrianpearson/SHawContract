using ShawContract.Application.Constants;
using ShawContract.Application.Contracts.Services;
using ShawContract.Providers.ShawNow.ProductService;
using ShawContract.Providers.ShawNow.StockCheckWS;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShawContract.Providers.ShawNow
{
    public class StockCheckService : IStockCheckService
    {
        public int CheckStock(string styleNumber, string colorNumber)
        {
            var deliveryVehicles = GetDeliveryVehicles(styleNumber);

            int quantity = 0;
            foreach (var deliveryVehicle in deliveryVehicles)
            {
                quantity += GetQuantity(styleNumber, colorNumber, deliveryVehicle);
            }

            return quantity;
        }

        private int GetQuantity(string styleNumber, string colorNumber, string deliveryVehicle)
        {
            var check = new StockCheck()
            {
                samplesPrivateStyle = styleNumber,
                delVehicle = deliveryVehicle,
                styleNbr = styleNumber,
                colorNbr = colorNumber,
                privateCode = ShawNowSettings.StockCheckPrivateCode,
                applicationId = ShawNowSettings.StockCheckApplicationID,
                custNbr = ShawNowSettings.StockCheckCustomerNumber,
                custRefNbr = ShawNowSettings.StockCheckCustomerReferenceNumber,
                location = ShawNowSettings.StockCheckLocation,
                productType = ShawNowSettings.StockCheckProductType,
                shipDate = DateTime.Now.ToString("MM/dd/yyyy"),
                userId = ShawNowSettings.StockCheckUserID
            };

            var result = new StockCheckWSClient().getStock(check);
            if (result.smpStockResult.result != null)
            {
                return (int)result.smpStockResult.result.Sum(i => i.availableQty);
            }

            return 0;
        }

        private IEnumerable<string> GetDeliveryVehicles(string styleNumber)
        {
            ProductSearchRequest request = new ProductSearchRequest()
            {
                applicationId = ShawNowSettings.StockCheckApplicationID,
                custNbr = ShawNowSettings.StockCheckCustomerNumber,
                styleNbr = styleNumber,
                userId = ShawNowSettings.StockCheckUserID,
                function = ShawNowSettings.StockFunction
            };

            var result = new ProductWSv2Client().getSamplesStyleList(request);

            foreach (var item in result.product.samplesStyleList)
            {
                yield return item.delVehNbr.Trim();
            }
        }
    }
}