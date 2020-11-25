using Microsoft.AspNetCore.Mvc;

namespace Example358
{
    public class HomeController : Controller
    {
        [ActionName("get-items")]
        public ActionResult GetItems()
        {
            return View();
        }
    }
}
