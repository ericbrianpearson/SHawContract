using ShawContract.Application.Contracts.Infrastructure;

namespace Shaw.Contract.UnitTests.Mocks
{
    public class MockedSiteContext : ISiteContextService
    {
        public string SiteName => "TestName";

        public string CurrentSiteCulture => "en-us";

        public int SiteContextID => 3;
    }
}