using System;
using System.Collections.Generic;

namespace Interview.Queries.Orders
{
    public class OrderDto
    {
        public OrderDto() => Items = new List<OrderItemDto>();

        public long     Id           { get; set; }
        public decimal  Total        { get; set; }
        public DateTime CreatedAt    { get; set; }
        public string   CustomerName { get; set; }

        public List<OrderItemDto> Items { get; set; }
    }

    public class OrderItemDto
    {
        public string  ProductName { get; set; }
        public decimal Price       { get; set; }
        public int     Quantity    { get; set; }
    }
}