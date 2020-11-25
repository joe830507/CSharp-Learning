using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Example364
{
    [Route("[controller]/[action]")]
    public class DemoController : Controller
    {
        [HttpPost]
        public ActionResult UploadFile()
        {
            var request = HttpContext.Request;
            Stream stream = request.Body;
            byte[] data = null;
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyToAsync(ms);
                data = ms.ToArray();
            }
            string fileName = request.Headers["file-name"];
            return Ok($"Uploaded file {fileName ?? "unknown"},Length:{data.Length} bytes");
        }
    }
}
