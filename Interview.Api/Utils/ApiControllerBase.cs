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
        public ApiControllerBase(MediatR.IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        public Task<Result> DispatchAsync(IRequest<Result> request) => Mediator.Send(request);
    }
}
