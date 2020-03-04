using System;
using System.Threading.Tasks;
using ShawContract.Application.Constants;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Providers.ShawNow.ExecuteOrdersWS;

namespace ShawContract.Providers.ShawNow
{
    public class SendOrderService : ISendOrderService
    {
        private IOrderBuilder OrderBuilder { get; set; }
        private IShoppingCartService ShoppingCartService { get; set; }

        public SendOrderService(IOrderBuilder orderBuilder, IShoppingCartService shoppingCartService)
        {
            OrderBuilder = orderBuilder;
            ShoppingCartService = shoppingCartService;
        }

        public async Task<int> SendOrder(Order orderInfo)
        {
            var address = orderInfo.ShippingAddress;

            var client = new OrderSampleClient();
            client.ClientCredentials.UserName.UserName = ShawNowSettings.OrderUserName;
            client.ClientCredentials.UserName.Password = ShawNowSettings.OrderPassword;
            var order = await client.CreateSampleOrderAsync(OrderBuilder.BuildOrder(orderInfo));

            int.TryParse(order.OrderNumber, out int orderNumber);

            if (orderNumber > 0)
            {
                orderInfo.OrderNumber = orderNumber;

                await ShoppingCartService.SaveOrder(orderInfo);

                return orderNumber;
            }
            else
            {
                throw new ApplicationException(order.MessageType);
            }
        }
    }
}