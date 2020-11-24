using Microsoft.AspNetCore.Mvc;

namespace Example352
{
    public class DemoController : Controller
    {
        public ActionResult Default()
        {
            return Content("This is a web app.");
        }
    }
}
