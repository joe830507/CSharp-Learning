using Microsoft.AspNetCore.Mvc;

namespace Example357
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Let this method inaccessible.
        [NonAction]
        public string SayHello()
        {
            return "Hello World";
        }
    }
}
