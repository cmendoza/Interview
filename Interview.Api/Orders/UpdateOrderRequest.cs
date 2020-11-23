namespace Interview.Api.Orders
{
    public class UpdateOrderRequest
    {
        public long ProductId { get; set; }
        public int  Quantity  { get; set; }
    }
}