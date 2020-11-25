using Microsoft.AspNetCore.Mvc;

namespace Example355
{
    public class DemoController : Controller
    {
        public ActionResult GetInfo([FromQuery]string mode)
        {
            if (mode == "preview")
                return View("Preview");
            else if (mode == "pagedview")
                return View("Pagedview");
            else
                return View("~/Views/Default.cshtml");
        }
    }
}
