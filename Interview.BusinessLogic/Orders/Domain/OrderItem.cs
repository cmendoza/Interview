using Interview.BusinessLogic.Products.Domain;

namespace Interview.BusinessLogic.Orders.Domain
{
    public partial class OrderItem : Common.Entity
    {
        protected OrderItem() { }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Price = product.Price;
            Quantity = quantity;
        }

        public decimal Price    { get; protected set; }
        public int     Quantity { get; protected set; }

        public virtual Product Product { get; protected set; }
    }
}
