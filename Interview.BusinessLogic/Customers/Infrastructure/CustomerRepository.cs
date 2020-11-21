using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Customers.Domain;

namespace Interview.BusinessLogic.Customers.Infrastructure
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(OrdersContext context) : base(context) { }
    }
}
