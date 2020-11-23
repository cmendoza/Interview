using Interview.BusinessLogic.Products.Domain;
using System;
using System.Collections.Generic;

#nullable disable

namespace Interview.BusinessLogic
{
    public partial class OrderItem
    {
        public long Id { get; set; }
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
