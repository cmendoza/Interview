using Interview.Api.Utils;
using Interview.BusinessLogic.Customers.Application;
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
    }
}
