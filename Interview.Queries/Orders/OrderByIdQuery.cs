using Dapper;
using Interview.Queries.Utils;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Queries.Orders
{
    public sealed class OrderByIdQuery : MediatR.IRequest<OrderDto>
    {
        public OrderByIdQuery(long id) => Id = id;

        public long Id { get; }
    }

    internal sealed class OrderByIdQueryHandler : MediatR.IRequestHandler<OrderByIdQuery, OrderDto>
    {
        private readonly QueriesConnectionString _connectionString;

        public OrderByIdQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<OrderDto> Handle(OrderByIdQuery request, CancellationToken cancellationToken)
        {
            var sqlQuery = @"
                SELECT
                    o.Id,
                    o.Total,
                    o.CreatedAt,
                    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
                    oi.Id,
                    oi.Quantity,
                    oi.Price,
                    p.Name AS ProductName
                FROM
                    Orders o
                    JOIN Customers c ON c.Id = o.CustomerId
                    LEFT JOIN OrderItems oi ON o.Id = oi.OrderId
                    LEFT JOIN Products p ON p.Id = oi.ProductId
                WHERE
                    o.Id = @Id";

            using (var sqlConnection = new SqlConnection(_connectionString.Value))
            {
                OrderDto fullOrder = null;

                await sqlConnection.QueryAsync<OrderDto, OrderItemDto, OrderDto>(sqlQuery,
                    (order, item) =>
                    {
                        if (fullOrder is null)
                        {
                            fullOrder = order;
                        }

                        fullOrder.Items.Add(item);

                        return order;
                    }, param: request);

                return fullOrder;
            }
        }
    }
}
