using Interview.Api.Utils;
using Interview.BusinessLogic.Orders.Application;
using Interview.Queries.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interview.Api.Orders
{
    public class OrdersController : ApiControllerBase
    {
        public OrdersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            var command = new CreateOrderCommand(request.CustomerId);

            var result = await DispatchAsync(command);

            return FromResult(result);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddItem(long id, [FromBody] UpdateOrderRequest request)
        {
            var command = new AddItemToCartCommand(id, request.ProductId, request.Quantity);

            var result = await DispatchAsync(command);

            return FromResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new AllOrdersQuery();

            var result = await DispatchAsync(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var query = new OrderByIdQuery(id);

            var result = await DispatchAsync(query);

            return result != null ? Ok(result) : NotFound($"OrderId doesn't exist: {id}");
        }
    }
}
