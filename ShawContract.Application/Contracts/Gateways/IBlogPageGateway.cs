using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IBlogPageGateway
    {
        BlogPage GetBlogPage(string nodeAlias);
    }
}
