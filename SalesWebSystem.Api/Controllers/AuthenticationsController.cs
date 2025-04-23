using Microsoft.AspNetCore.Mvc;

namespace SalesWebSystem.Api.Controllers
{
    public class AuthenticationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
