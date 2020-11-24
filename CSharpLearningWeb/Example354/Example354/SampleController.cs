using Microsoft.AspNetCore.Mvc;

namespace Example354
{
    [Route("[controller]/[action]")]
    public class SampleController : Controller
    {
        public IActionResult Test1() => View();
        public IActionResult Test2() => View();
    }
}
