using ShawContract.Application.Models;

namespace ShawContract.Application.Contracts.Services
{
    public interface IGenericContentPageService
    {
        GenericContentPage GetGenericContentPage(string pageAlias);
    }
}