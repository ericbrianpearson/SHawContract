using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Contracts.Gateways;
using ShawContract.Application.Contracts.Services;
using ShawContract.Application.Models;

namespace ShawContract.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogGateway BlogGateway;

        public BlogService(IBlogGateway blogGateway)
        {
            this.BlogGateway = blogGateway;
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            return await this.BlogGateway.GetAllBlogsAsync();
        }
    }
}