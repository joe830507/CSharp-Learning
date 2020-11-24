using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Example347.Demopages
{
    public class TestModel : PageModel
    {
        [BindProperty]
        public string ProductName { get; set; }
        [BindProperty]
        public DateTime ProductDate { get; set; }
        [BindProperty]
        public Guid ProductID { get; set; }
        [BindProperty]
        public string ProductFamily { get; set; }
        public void OnGet()
        {
            ProductID = Guid.NewGuid();
            ProductDate = DateTime.Now;
            ProductName = "Unkown Product";
            ProductFamily = "unclassified";
        }

        public void OnPost()
        {
            ViewData["msg"] = "Finished";
        }
    }
}
