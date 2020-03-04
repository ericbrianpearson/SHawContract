using System.Threading.Tasks;

namespace ShawContract.Application.Contracts.Services
{
    public interface IStockCheckService
    {
        int CheckStock(string styleNumber, string colorNumber);
    }
}