using CMS.DataEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShawContract.Application.Models;
using ShawContract.Config;
using ShawContract.Infrastructure;
using ShawContract.Providers.Kentico;
using ShawContract.Providers.Kentico.PageHandler;
using ShawContract.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Shaw.Contract.UnitTests.Providers.Kentico
{
    [TestClass]
    public class KenticoAPITest
    {
        private const string culture = "en-us";
        private const string siteName = "ShawContract";

        private PageContentHandler handler;
        private SiteContextService service;

        private AccountGateway AccountGateway;
        private MenuGateway MenuGateway;
        private CultureInfoGateway CultureInfoGateway;

        [TestInitialize]
        public void TestInit()
        {
            CMSApplication.PreInit();
            service = new SiteContextService(culture, siteName);
            handler = new PageContentHandler(service);
        }

        [TestMethod]
        public void GetAccountTest()
        {
            AccountGateway = new AccountGateway(handler);
            var item = AccountGateway.GetAccount();

            Assert.IsNotNull(item);
            Assert.IsInstanceOfType(item, typeof(Account));
        }

        [TestMethod]
        public void GetMenuItemsTest()
        {
            MenuGateway = new MenuGateway(handler, new CachingService(), new LoggingService(), AutoMapperConfig.RegisterAutoMappings());
            var menuItems = MenuGateway.GetHeaderMenuItems();

            Assert.IsNotNull(menuItems);
            Assert.IsInstanceOfType(menuItems, typeof(IEnumerable<MenuItem>));
            Assert.IsTrue(menuItems.Count() > 0);
        }

        [TestMethod]
        public void GetCultureInfoTest()
        {
            CultureInfoGateway = new CultureInfoGateway(service);
            var cultures = CultureInfoGateway.GetSiteCultures();

            Assert.IsNotNull(cultures);
            Assert.IsInstanceOfType(cultures, typeof(IEnumerable<CultureInfo>));
        }
    }
}