using System;
using System.Collections.Generic;

namespace ShawContract.Application.Models
{
    public class Order
    {
        public int OrderNumber { get; set; } //OrderInvoiceNumber -> order #
        public Address ShippingAddress { get; set; } //OrderBillingAddress
        public string ProjectName { get; set; } //OrderNote ->
        public int AccountNumber { get; set; } //OrderShippingOptionID
        public string ShippingMethod { get; set; }

        public DateTime OrderDateSubmitted { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}