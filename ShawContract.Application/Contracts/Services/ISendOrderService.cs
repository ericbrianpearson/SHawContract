using ShawContract.Application.Models;
using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Services
{
    public interface ISendOrderService
    {
        Task<int> SendOrder(Order order);
    }
}