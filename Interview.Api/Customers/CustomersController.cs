using Interview.Api.Utils;
using Interview.BusinessLogic.Customers.Application;
using Interview.Queries.Customers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interview.Api.Customers
{
    public class CustomersController : ApiControllerBase
    {
        public CustomersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
        {
            var command = new CreateCustomerCommand(request.FirstName, request.LastName);

            var result = await DispatchAsync(command);

            return FromResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCustomerRequest request)
        {
            var command = new UpdateCustomerCommand(id, request.FirstName, request.LastName);

            var result = await DispatchAsync(command);

            return FromResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new AllCustomersQuery();

            var result = await DispatchAsync(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var query = new CustomerByIdQuery(id);

            var result = await DispatchAsync(query);

            return Ok(result);
        }
    }
}
