using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Example362
{
    [Route("[controller]/[action]")]
    public class DemoController : Controller
    {
        IEnumerable<ITestService> _encoders;
        public DemoController(IEnumerable<ITestService> svs)
        {
            _encoders = svs;
        }

        [HttpGet]
        public JsonResult Encode()
        {
            string q = Request.Query["text"];
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic["text"] = q;
            foreach (var sv in _encoders)
            {
                string r = sv.GetResult(q);
                dic[sv.HashName] = r;
            }
            return Json(dic);
        }
    }
}
