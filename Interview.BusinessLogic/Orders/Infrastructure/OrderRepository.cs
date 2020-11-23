using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Orders.Domain;

namespace Interview.BusinessLogic.Orders.Infrastructure
{
    internal sealed class OrderRepository : Repository<Order>
    {
        public OrderRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
