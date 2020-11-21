using Interview.BusinessLogic.Common;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Interview.Api.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private const string ConnectionString = @"Server=LAPTOP-S3NFKIGO\SQLEXPRESS;Database=TestDb;Trusted_Connection=True;";

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            using (var context = new OrdersContext(ConnectionString))
            {
                var order = context.Orders.Find(id);

                if (order == null) return NotFound();

                return Ok(order);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            using (var context = new OrdersContext(ConnectionString))
            {
                var orders = context.Orders.ToList();

                return Ok(orders);
            }
        }
    }
}
