using Microsoft.AspNetCore.Mvc;

namespace Example356
{
    [Controller]
    public class MyController
    {
        public ActionResult Index()
        {
            ViewResult res = new ViewResult
            {
                ViewName = "Default"
            };
            return res;
        }
    }
}
