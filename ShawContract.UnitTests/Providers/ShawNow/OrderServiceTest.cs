using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Shaw.Contract.UnitTests.SampleOrder;

namespace Shaw.Contract.UnitTests.Providers.ShawNow
{
    [TestClass]
    public class OrderServiceTest
    {
        private SampleOrderHeader OrderHeader { get; set; }

        [TestInitialize]
        public void Init()
        {
            OrderHeader = new SampleOrderHeader();
            OrderHeader.AcctNumber = 2006;
            OrderHeader.CarrierName = "Ground";
            OrderHeader.ProjectName = "Random project";
            OrderHeader.Requester = "SCG";

            OrderHeader.ShipToAddress = new OrderAddress()
            {
                Name = "John",
                Name2 = "Doe",
                PhoneNumber = "206-442-6090",
                City = "Seattle",
                Country = "USA",
                Line1 = "Some random address here",
                Line2 = "Address 2 University",
                State = "WA",
                Zip = "98101"
            };

            OrderHeader.Lines = new SampleOrderLines();

            OrderHeader.Lines.Add(new SampleOrderLine()
            {
                Style = "CA362",
                Color = "01027",
                Qty = 1,
            });
        }

        [TestMethod]
        public async Task SendOrder_Test()
        {
            var client = new OrderSampleClient();
            client.ClientCredentials.UserName.UserName = "FluidMedia";
            client.ClientCredentials.UserName.Password = "shaw2013";
            var order = await client.CreateSampleOrderAsync(OrderHeader);

            int.TryParse(order.OrderNumber, out int number);
            Assert.IsInstanceOfType(number, typeof(int));
            Assert.AreNotEqual(number, 0);
        }
    }
}