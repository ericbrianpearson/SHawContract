using ShawContract.Application.Models;
using ShawContract.Providers.ShawNow.ExecuteOrdersWS;
using System.Collections.Generic;

namespace ShawContract.Providers.ShawNow
{
    public interface IOrderBuilder
    {
        SampleOrderHeader BuildOrder(Order orderInfo);
    }
}