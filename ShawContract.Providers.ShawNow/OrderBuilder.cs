using ShawContract.Application.Constants;
using ShawContract.Application.Models;
using ShawContract.Providers.ShawNow.ExecuteOrdersWS;
using System.Collections.Generic;

namespace ShawContract.Providers.ShawNow
{
    public class OrderBuilder : IOrderBuilder
    {
        public SampleOrderHeader OrderHeader;

        private Order OrderInfo { get; set; }

        public SampleOrderHeader BuildOrder(Order orderInfo)
        {
            OrderHeader = new SampleOrderHeader();
            OrderInfo = orderInfo;

            GetAccountNumber();
            GetCarrierName();
            GetRequester();
            GetShippingAddress();
            GetOrderLines();

            return OrderHeader;
        }

        private void GetAccountNumber()
        {
            OrderHeader.AcctNumber =
                OrderInfo.AccountNumber = OrderInfo.AccountNumber > 0 ? OrderInfo.AccountNumber : ShawNowSettings.OrderAccountNumberUS;
        }

        private void GetCarrierName()
        {
            OrderHeader.CarrierName = OrderInfo.ShippingMethod;
        }

        private void GetRequester()
        {
            OrderHeader.Requester = ShawNowSettings.OrderRequester;
        }

        private void GetProjectName()
        {
            OrderHeader.ProjectName = OrderInfo.ProjectName;
        }

        private void GetShippingAddress()
        {
            OrderHeader.ShipToAddress = new OrderAddress
            {
                Name = OrderInfo.ShippingAddress.FirstName,
                Name2 = OrderInfo.ShippingAddress.LastName,
                PhoneNumber = OrderInfo.ShippingAddress.Phone,
                City = OrderInfo.ShippingAddress.City,
                Country = OrderInfo.ShippingAddress.CountryName,
                Line1 = OrderInfo.ShippingAddress.Line1,
                Line2 = OrderInfo.ShippingAddress.Line2,
                State = OrderInfo.ShippingAddress.StateCode,
                Zip = OrderInfo.ShippingAddress.Zip
            };
        }

        private void GetOrderLines()
        {
            OrderHeader.Lines = new SampleOrderLines();

            foreach (var item in OrderInfo.OrderItems)
            {
                OrderHeader.Lines.Add(new SampleOrderLine()
                {
                    Style = item.StyleNumber,
                    Color = item.ColorNumber,
                    Qty = item.Quantity,
                });
            }
        }
    }
}