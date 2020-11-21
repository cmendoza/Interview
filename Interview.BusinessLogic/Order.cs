using Interview.BusinessLogic.Customers.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace Interview.BusinessLogic
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
