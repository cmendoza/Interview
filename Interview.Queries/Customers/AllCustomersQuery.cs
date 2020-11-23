using Dapper;
using Interview.Queries.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Queries.Customers
{
    public sealed class AllCustomersQuery : MediatR.IRequest<List<CustomerDto>>
    {
        public AllCustomersQuery() { }
    }

    internal sealed class AllCustomersQueryHandler : MediatR.IRequestHandler<AllCustomersQuery, List<CustomerDto>>
    {
        private readonly QueriesConnectionString _connectionString;

        public AllCustomersQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<CustomerDto>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        {
            var sqlQuery = "SELECT * FROM Customers";

            using (var sqlConnection = new SqlConnection(_connectionString.Value))
            {
                var result = await sqlConnection.QueryAsync<CustomerDto>(sqlQuery);

                return result.AsList();
            }
        }
    }
}
