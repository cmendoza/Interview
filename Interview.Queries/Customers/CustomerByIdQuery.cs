using Dapper;
using Interview.Queries.Utils;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Queries.Customers
{
    public sealed class CustomerByIdQuery : MediatR.IRequest<CustomerDto>
    {
        public CustomerByIdQuery(long id) => Id = id;

        public long Id { get; }
    }

    internal sealed class CustomerByIdQueryHandler : MediatR.IRequestHandler<CustomerByIdQuery, CustomerDto>
    {
        private readonly QueriesConnectionString _connectionString;

        public CustomerByIdQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<CustomerDto> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var sqlQuery = "SELECT * FROM Customers WHERE Id = @Id";

            using (var sqlConnection = new SqlConnection(_connectionString.Value))
            {
                var result = await sqlConnection.QueryFirstOrDefaultAsync<CustomerDto>(sqlQuery, request);

                return result;
            }
        }
    }
}
