using Interview.Web.Models;
using Interview.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Interview.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApiEndpoint _endpoint;

        public OrdersController(ApiEndpoint endpoint)
        {
            _endpoint = endpoint;
        }

        public IActionResult Index()
        {
            var client = new RestClient(_endpoint.Value).UseNewtonsoftJson();
            var request = new RestRequest("/orders/1");

            var response = client.Get<Envelope<OrderDto>>(request);

            return View(response.Data.Result);
        }
    }
}
