using Microsoft.AspNetCore.Mvc;

namespace SalesWebSystem.Api.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
