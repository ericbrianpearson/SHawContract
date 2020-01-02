using System.Collections.Generic;
using System.Threading.Tasks;
using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllBlogs();
    }
}