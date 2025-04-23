using Microsoft.AspNetCore.Mvc;

namespace SalesWebSystem.Api.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
