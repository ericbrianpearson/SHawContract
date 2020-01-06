using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface IBlogGateway
    {
        Task<IEnumerable<Blog>> GetAllBlogsAsync();
    }
}