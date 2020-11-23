using Interview.Api.Utils;
using Interview.BusinessLogic.Products.Application;
using Interview.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interview.Api.Products
{
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var command = new CreateProductCommand(request.Name, request.Price);

            var result = await DispatchAsync(command);

            return FromResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateProductRequest request)
        {
            var command = new UpdateProductCommand(id, request.Name, request.Price);

            var result = await DispatchAsync(command);

            return FromResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new AllProductsQuery();

            var result = await DispatchAsync(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var query = new ProductByIdQuery(id);

            var result = await DispatchAsync(query);

            return result != null ? Ok(result) : NotFound($"ProductId doesn't exist: {id}");
        }
    }
}
