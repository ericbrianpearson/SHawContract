using ShawContract.Application.Contracts.Infrastructure;

namespace Shaw.Contract.UnitTests.Mocks
{
    public class MockedSiteContext : ISiteContextService
    {
        public string CurrentSiteCulture => "en-us";

        public int SiteContextID => throw new System.NotImplementedException();

        public string SiteName => "TestName";
    }
}
