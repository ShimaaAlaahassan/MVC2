using Microsoft.AspNetCore.Mvc;

namespace MVC2.Controllers
{
    public class locationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
