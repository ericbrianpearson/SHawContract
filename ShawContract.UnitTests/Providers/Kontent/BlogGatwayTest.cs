using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shaw.Contract.UnitTests.Mocks;
using ShawContract.Providers.Kontent;
using ShawContract.Infrastructure;
using ShawContract.Config;

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
            var blogGateway = new BlogGateway(MockedKontentProvider.GetKontentProvider(),
                              new MockedSiteContext(),
                              AutoMapperConfig.RegisterAutoMappings());

            var items = await blogGateway.GetAllBlogsAsync();

            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count() > 0);
        }

        [TestMethod]
        public async Task GetKontentItemAssertNotNull()
        {
            string seoUrl = "seeking-the-horizon";
            var blogGateway = new BlogGateway(MockedKontentProvider.GetKontentProvider(), 
                              new MockedSiteContext(),
                              AutoMapperConfig.RegisterAutoMappings());

            var blog = await blogGateway.GetBlogAsync(seoUrl);
            Assert.IsNotNull(blog);
        }

        [TestMethod]
        public async Task GetKontentTaxonomyTermsAssertNotNullOrEmpty()
        {
            var blogGateway = new BlogGateway(MockedKontentProvider.GetKontentProvider(),
                              new MockedSiteContext(),
                              AutoMapperConfig.RegisterAutoMappings());

            var taxonomyTerms = await blogGateway.GetTaxonomyAsync();
            Assert.IsNotNull(taxonomyTerms);
            Assert.IsTrue(taxonomyTerms.Personas.Count() > 0);
        }

        [TestMethod]
        public async Task FilterKontentItemsAssertNotNull()
        {
            string persona = "designer";
            string segment = "healthcare";
            var blogGateway = new BlogGateway(MockedKontentProvider.GetKontentProvider(),
                              new MockedSiteContext(),
                              AutoMapperConfig.RegisterAutoMappings());

            var blog = await blogGateway.FilterByTagsAsync(persona, segment);
            Assert.IsNotNull(blog);
        }

        [TestMethod]
        public async Task GetArticlesByTagAssertNotNull()
        {
            string persona = "designer";
            string segment = "healthcare";
            var blogGateway = new BlogGateway(MockedKontentProvider.GetKontentProvider(),
                              new MockedSiteContext(),
                              AutoMapperConfig.RegisterAutoMappings());

            var blogByPersona = await blogGateway.ArticlesByPersonaAsync(persona);
            var blogBySegment = await blogGateway.ArticlesBySegmentAsync(segment);

            Assert.IsNotNull(blogByPersona);
            Assert.IsNotNull(blogBySegment);
        }
    }
}