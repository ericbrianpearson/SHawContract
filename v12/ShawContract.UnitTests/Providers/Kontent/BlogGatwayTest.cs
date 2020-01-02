using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shaw.Contract.UnitTests.Mocks;
using ShawContract.Providers.Kontent;

namespace ShawContract.UnitTests.Services.Kontent
{
    [TestClass]
    public class KontentAPITests
    {
        public KontentAPITests()
        {
        }

        [TestMethod]
        public async Task GetKontentItemsAssertNotNullorEmpty()
        {
            var blogGateway = new BlogGateway(MockedKontentProvider.GetKontentProvider(), new MockedSiteContext());
            var items = await blogGateway.GetAllBlogsAsync();

            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count() > 0);
        }
    }
}