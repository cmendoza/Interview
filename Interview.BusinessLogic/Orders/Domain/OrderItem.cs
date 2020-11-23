using Interview.BusinessLogic.Products.Domain;
using System;

namespace Interview.BusinessLogic.Orders.Domain
{
    public partial class OrderItem : Common.Entity
    {
        protected OrderItem() { }

        public OrderItem(Order order, Product product, int quantity)
        {
            Order = order;
            Product = product;
            Price = product.Price;
            Quantity = quantity;
        }

        public decimal Price    { get; protected set; }
        public int     Quantity { get; protected set; }

        public virtual Product Product { get; protected set; }
        public virtual Order   Order   { get; protected set; }

        public void UpdateQuantity(int newQuantity)
        {
            if (newQuantity <= 0) throw new ArgumentException("Quantity must be greater than zero.");

            Quantity = newQuantity;
        }
    }
}
