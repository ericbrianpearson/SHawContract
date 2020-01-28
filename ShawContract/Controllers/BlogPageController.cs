using Kentico.PageBuilder.Web.Mvc;
using Kentico.Web.Mvc;
using ShawContract.Application.Contracts.Services;
using ShawContract.Models.Blogs;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace ShawContract.Controllers
{
    public class BlogPageController : BaseController
    {
        private IBlogService BlogService { get; }

        public BlogPageController(IMasterPageService masterPageService,
                                  IBlogService blogService)
               : base(masterPageService)
        {
            BlogService = blogService;
        }

        [OutputCache(Duration = 3600, VaryByParam = "nodeAlias", Location = OutputCacheLocation.Server)]
        public async Task<ActionResult> Index(string nodeAlias)
        {
            var blogs = await BlogService.GetAllBlogsAsync();
            var page = BlogService.GetPage(nodeAlias);

            if (page == null) return HttpNotFound();

            var taxonomy = await BlogService.GetTaxonomyTermsAsync();
            var blogModel = new BlogPageViewModel()
            {
                Articles = blogs,
                Personas = taxonomy.Personas,
                Segments = taxonomy.Segments
            };
            HttpContext.Kentico().PageBuilder().Initialize(page.DocumentID);
            var model = GetPageViewModel(blogModel, nodeAlias);

            return View(model);
        }

        [OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")]
        public async Task<ActionResult> Details(string nodeAlias, string seoUrl)
        {
            var article = await BlogService.GetBlogAsync(seoUrl);
            var viewModel = new BlogDetailsViewModel() { Article = article };
            var model = GetPageViewModel(viewModel, nodeAlias);

            return View(model);
        }

        public async Task<ActionResult> Filter(string nodeAlias, string persona, string segment)
        {
            var blogs = await BlogService.FilterByTagsAsync(persona, segment);
            var blogModel = new BlogArticlesViewModel() { Articles = blogs.ToList() };

            return PartialView("_BlogArticlesPartial", blogModel);
        }

        public async Task<ActionResult> TaggedArticles(string nodeAlias, string type, string tag)
        {
            var blogs = await BlogService.GetTaggedArticlesAsync(type, tag);
            var blogModel = new BlogsByTagViewModel() { Articles = blogs, SelectedTag = char.ToUpper(tag[0]) + tag.Substring(1), Cta = blogs.FirstOrDefault().Cta };
            var model = GetPageViewModel(blogModel, nodeAlias);

            return View(model);
        }
    }
}