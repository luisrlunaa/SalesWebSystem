using Microsoft.AspNetCore.Mvc;

namespace SalesWebSystem.Api.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
