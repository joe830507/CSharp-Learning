using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Example353
{
    [Route("/products")]
    [Controller]
    public class ProductController : Controller
    {
        [Route("list")]
        public ActionResult GetList()
        {
            return Content("Product List");
        }
    }
}
