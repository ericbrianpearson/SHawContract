using AutoMapper;
using CMS.DocumentEngine.Types.ShawContract;
using CMS.Ecommerce;
using CMS.SiteProvider;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Infrastructure;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;
using ShawContract.Application.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShawContract.Providers.Kentico
{
    public class ShoppingCartGateway : IShoppingCartGateway
    {
        private IShoppingService ShoppingService { get; set; }
        private ISiteContextService SiteContextService { get; set; }
        private IMapper Mapper { get; set; }
        private ICachingService CachingService { get; set; }
        private IStockCheckService StockCheckService { get; set; }

        private IProductsService ProductsService { get; }

        public ShoppingCartGateway(IShoppingService shoppingService, IMapper mapper, ISiteContextService siteContextService,
                                    ICachingService cachingService, IStockCheckService stockCheckService,
                                    IProductsService productsService)
        {
            SiteContextService = siteContextService;
            ShoppingService = shoppingService;
            CachingService = cachingService;
            StockCheckService = stockCheckService;
            ProductsService = productsService;
            Mapper = mapper;
        }

        public ShoppingCart GetCurrentShoppingCart()
        {
            return GetShoppingCart();
        }

        public ShoppingCartPage GetShoppingCartPage()
        {
            var itemsCount = GetShoppingCart().CartItems.Count;

            return CartPageProvider.GetCartPages()
               .LatestVersion(true)
               .OnSite(SiteContext.CurrentSiteName)
               .TopN(1)
               .Select(cp => new ShoppingCartPage { Title = cp.Title, Description = cp.Description, CartItemsCount = itemsCount })
               .SingleOrDefault();
        }

        public ShoppingCartPage GetFinalizeSubmitPage()
        {
            return FinalizeSubmitProvider.GetFinalizeSubmits()
                .LatestVersion(true)
                .OnSite(SiteContext.CurrentSiteName)
                .TopN(1)
                .Select(cp => new ShoppingCartPage { Title = cp.Title, Description = cp.Description })
                .SingleOrDefault();
        }

        public void AddItemToCart(int variantSkuId, int quantity)
        {
            this.ShoppingService.AddItemToCart(new ShoppingCartItemParameters(variantSkuId, quantity));
        }

        public void UpdateItemQuantity(int itemId, int quantity)
        {
            this.ShoppingService.UpdateItemQuantity(itemId, quantity);
        }

        public void RemoveItemFromCart(int id)
        {
            ShoppingService.RemoveItemFromCart(id);
        }

        public void RemoveAllItemsFromCart()
        {
            ShoppingService.RemoveAllItemsFromCart();
        }

        public IEnumerable<CollectionProduct> GetCartSimilarProducts(ShoppingCart cart)
        {
            List<CollectionProduct> productList = new List<CollectionProduct>();
            foreach (var cartItem in cart.CartItems)
            {
                var product = ProductsService.GetProductPage(cartItem.ProductType, cartItem.ItemName.Replace(' ', '-'));
                var similarProducts = ProductsService.GetSimilarProducts(product.SimilarProducts, cartItem.ProductType);
                productList.AddRange(similarProducts);
            }

            return SortCartSimilarProducts(productList);
        }

        public async Task SaveOrder(Order order)
        {
            var newOrder = new OrderInfo
            {
                OrderInvoiceNumber = order.OrderNumber.ToString(),
                OrderNote = order.ProjectName,
                OrderDate = DateTime.UtcNow,
                OrderTotalPrice = 0,
                OrderGrandTotal = 0,
                OrderTotalTax = 0,

                OrderCustomerID = await CreateCustomer(order.Customer),
                OrderCompletedByUserID = order.Customer.CustomerUserId,
                OrderSiteID = SiteContext.CurrentSiteID,
                OrderCurrencyID = 1,
            };

            await Task.Run(() => OrderInfoProvider.SetOrderInfo(newOrder));

            foreach (var item in order.OrderItems)
            {
                OrderItemInfo newItem = new OrderItemInfo
                {
                    OrderItemSKUName = item.ColorName,
                    OrderItemSKUID = item.SKUID,
                    OrderItemUnitPrice = 0,
                    OrderItemTotalPrice = 0,
                    OrderItemOrderID = newOrder.OrderID,
                    OrderItemText =
                        string.Join(",", new string[] { item.StyleName, item.StyleNumber, item.ColorNumber }), //page
                    OrderItemUnitCount = (int)item.Quantity, //page
                };

                await Task.Run(() => OrderItemInfoProvider.SetOrderItemInfo(newItem));
            }
        }

        public async Task<IEnumerable<Order>> GetOrderHistory(int userId)
        {
            var orders = await Task.Run(() => OrderInfoProvider.GetOrders()
                .WhereEquals("OrderCreatedByUserID", userId)
                .ToList());

            var mappedOrders = Mapper.Map<IEnumerable<OrderInfo>, IEnumerable<Order>>(orders);

            for (var index = 0; index < orders.Count; index++)
            {
                var orderItems = await Task.Run(() => OrderItemInfoProvider.GetOrderItems()
                    .WhereEquals("OrderItemOrderID", orders[index].OrderID)
                    .ToList());

                var orderItemsList = new List<OrderItem>();
                foreach (var orderItem in orderItems)
                {
                    var url = await Task.Run(() => SKUInfoProvider.GetSKUs()
                           .WhereEquals("SKUID", orderItem.OrderItemSKUID)
                           .Select(sku => sku.SKUImagePath)
                           .SingleOrDefault());

                    var historyOrderItem = new OrderItem
                    {
                        PictureUrl = url,
                        StyleName = orderItem.OrderItemText.Split(',')[0],
                        StyleNumber = orderItem.OrderItemText.Split(',')[1],
                        ColorName = orderItem.OrderItemSKUName,
                        ColorNumber = orderItem.OrderItemText.Split(',')[2],
                        Quantity = orderItem.OrderItemUnitCount
                    };

                    orderItemsList.Add(historyOrderItem);
                }

                mappedOrders.ElementAt(index).OrderItems = orderItemsList;
            }

            return mappedOrders;
        }

        private IEnumerable<CollectionProduct> SortCartSimilarProducts(IEnumerable<CollectionProduct> productList)
        {
            return productList
                 .GroupBy(p => p.StyleNumber)
                 .OrderByDescending(p => p.Count())
                 .SelectMany(p => p)
                 .GroupBy(p => p.StyleName)
                 .Select(p => p.First())
                 .Take(4)
                 .OrderBy(p => p.StyleName)
                 .AsEnumerable();
        }

        private async Task<int> CreateCustomer(Customer customer)
        {
            CustomerInfo customerInfo = await Task.Run(() => CustomerInfoProvider.GetCustomers()
                .WhereEquals("CustomerUserId", customer.CustomerUserId)
                .TopN(1)
                .FirstOrDefault());

            if (customerInfo != null)
            {
                return customerInfo.CustomerID;
            }

            CustomerInfo newCustomer = new CustomerInfo()
            {
                CustomerFirstName = customer.FirstName,
                CustomerLastName = customer.LastName,
                CustomerEmail = customer.Email,
                CustomerSiteID = SiteContext.CurrentSiteID,
                CustomerUserID = customer.CustomerUserId,
            };

            await Task.Run(() => CustomerInfoProvider.SetCustomerInfo(newCustomer));

            return newCustomer.CustomerID;
        }

        private ShoppingCart GetShoppingCart()
        {
            var cart = ShoppingService.GetCurrentShoppingCart();
            //CheckStock(mappedCart); TODO: uncomment when integration with ShawNow is ready
            return Mapper.Map<ShoppingCartInfo, ShoppingCart>(cart);
        }
    }
}