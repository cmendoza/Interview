using Dapper;
using Interview.Queries.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Interview.Queries.Orders
{
    public sealed class AllOrdersQuery : MediatR.IRequest<List<OrderDto>>
    {
        public AllOrdersQuery() { }
    }

    internal sealed class AllOrdersQueryHandler : MediatR.IRequestHandler<AllOrdersQuery, List<OrderDto>>
    {
        private readonly QueriesConnectionString _connectionString;

        public AllOrdersQueryHandler(QueriesConnectionString connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<OrderDto>> Handle(AllOrdersQuery request, CancellationToken cancellationToken)
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
                    LEFT JOIN Products p ON p.Id = oi.ProductId";

            using (var sqlConnection = new SqlConnection(_connectionString.Value))
            {
                var orders = new Dictionary<long, OrderDto>();

                await sqlConnection.QueryAsync<OrderDto, OrderItemDto, OrderDto>(sqlQuery,
                    (order, item) =>
                    {
                        var existingOrder = order;

                        if (!orders.ContainsKey(order.Id))
                        {
                            orders.Add(order.Id, order);
                        }

                        existingOrder = orders[order.Id];

                        if (item != null)
                        {
                            existingOrder.Items.Add(item);
                        }

                        return order;
                    });

                return orders.Values.ToList();
            }
        }
    }
}
