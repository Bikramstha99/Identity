using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AppRolesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
