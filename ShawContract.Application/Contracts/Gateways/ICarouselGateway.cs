using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Application.Contracts.Gateways
{
    public interface ICarouselGateway
    {
        IEnumerable<CarouselSection> GetCarouselSections(string nodeAlias);
    }
}
