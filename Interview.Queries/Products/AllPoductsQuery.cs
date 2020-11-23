using Dapper;
using Interview.Queries.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Queries.Products
{
    public sealed class AllProductsQuery : MediatR.IRequest<List<ProductDto>>
    {
        public AllProductsQuery() { }
    }

    internal sealed class AllProductsQueryHandler : MediatR.IRequestHandler<AllProductsQuery, List<ProductDto>>
    {
        private readonly QueriesConnectionString _connectionString;

        public AllProductsQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<ProductDto>> Handle(AllProductsQuery request, CancellationToken cancellationToken)
        {
            var sqlQuery = "SELECT * FROM Products";

            using (var sqlConnection = new SqlConnection(_connectionString.Value))
            {
                var result = await sqlConnection.QueryAsync<ProductDto>(sqlQuery);

                return result.AsList();
            }
        }
    }
}
