using Microsoft.AspNetCore.Mvc;

namespace SalesWebSystem.Api.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
