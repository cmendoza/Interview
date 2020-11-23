using Interview.BusinessLogic.Common;
using Interview.BusinessLogic.Products.Domain;

namespace Interview.BusinessLogic.Products.Infrastructure
{
    internal sealed class ProductRepository : Repository<Product>
    {
        public ProductRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
