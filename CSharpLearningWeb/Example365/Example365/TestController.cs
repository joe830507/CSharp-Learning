using Microsoft.AspNetCore.Mvc;

namespace Example365
{
    [Route("[controller]/[action]")]
    public class TestController : Controller
    {
        public IActionResult Default()
        {
            return View();
        }
    }
}
