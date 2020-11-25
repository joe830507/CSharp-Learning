using Microsoft.AspNetCore.Mvc;

namespace Example359
{
    public class TestController:Controller
    {
        public ActionResult Default()
        {
            ViewBag.Title = "MyEaseWebsite";
            return View();
        }
    }
}
