using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Example351.Pages
{
    public class testModel : PageModel
    {
        public ActionResult OnPostLoginPublic(string username, string password)
        {
            string msg = $"Login publicly, your username:{username},password:{password}";
            return Content(msg);
        }

        public ActionResult OnPostLoginHidden(string username, string password)
        {
            string msg = $"Login hiddenly, your username:{username},password:{password}";
            return Content(msg);
        }
    }
}
