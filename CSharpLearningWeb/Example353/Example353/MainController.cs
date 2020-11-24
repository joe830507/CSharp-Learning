using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Example353
{
    [Route("[controller]/[action]")]
    public class MainController : Controller
    {
        public ActionResult About()
        {
            return Content("About this site");
        }
        public ActionResult Home()
        {
            return Content("Home page");
        }
    }
}
