using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interview.Api.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiControllerBase(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected new IActionResult Ok() => base.Ok(Envelope.Ok());

        protected IActionResult Ok<T>(T result) => base.Ok(Envelope.Ok(result));

        protected IActionResult Error(string errorMessage) => StatusCode(400, Envelope.Error(errorMessage));

        protected IActionResult NotFound(string errorMessage) => NotFound(Envelope.Error(errorMessage));

        protected IActionResult FromResult(Result result) => result.IsSuccess ? Ok() : Error(result.Error);

        public Task<Result> DispatchAsync(IRequest<Result> request) => _mediator.Send(request);
    }
}
