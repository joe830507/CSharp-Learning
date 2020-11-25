using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Example361
{
    public class StudentController : Controller
    {
        public ActionResult AllStudents()
        {
            List<Student> stus = new List<Student>();
            stus.Add(new Student
            {
                ID = Guid.NewGuid(),
                Name = "Li",
                Age = 21,
                Course = "C#"
            });
            stus.Add(new Student
            {
                ID = Guid.NewGuid(),
                Name = "Lin",
                Age = 20,
                Course = "Golang"
            });
            stus.Add(new Student
            {
                ID = Guid.NewGuid(),
                Name = "Lu",
                Age = 22,
                Course = "C++"
            });
            ViewData.Model = stus;
            return View();
        }

    }
}
