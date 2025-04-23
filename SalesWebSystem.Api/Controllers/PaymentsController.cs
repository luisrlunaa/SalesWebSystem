using Microsoft.AspNetCore.Mvc;

namespace SalesWebSystem.Api.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
