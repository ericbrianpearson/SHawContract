using ShawContract.Application.Models;
using System.Collections.Generic;

namespace ShawContract.Models.OrderHistory
{
    public class OrderViewModel : IViewModel
    {
        public IEnumerable<Order> Orders { get; set; }

        public OrderViewModel(IEnumerable<Order> orders)
        {
            Orders = orders;
        }
    }
}