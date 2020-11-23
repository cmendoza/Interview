using Dapper;
using Interview.Queries.Utils;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Queries.Products
{
    public sealed class ProductByIdQuery : MediatR.IRequest<ProductDto>
    {
        public ProductByIdQuery(long id) => Id = id;

        public long Id { get; }
    }

    internal sealed class ProductByIdQueryHandler : MediatR.IRequestHandler<ProductByIdQuery, ProductDto>
    {
        private readonly QueriesConnectionString _connectionString;

        public ProductByIdQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<ProductDto> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
        {
            var sqlQuery = "SELECT * FROM Products WHERE Id = @Id";

            using (var sqlConnection = new SqlConnection(_connectionString.Value))
            {
                var result = await sqlConnection.QueryFirstOrDefaultAsync<ProductDto>(sqlQuery, request);

                return result;
            }
        }
    }
}
