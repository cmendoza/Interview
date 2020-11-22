using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Customers.Domain;

namespace Interview.BusinessLogic.Customers.Infrastructure
{
    internal sealed class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
