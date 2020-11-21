using Interview.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            var order = new Order();

            return View(order);
        }
    }
}
