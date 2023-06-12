using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    
        public IActionResult SongForm() => View();

        [HttpPost]
        public IActionResult Sing()
        {
            HttpContext.Session.SetString("noOfMonkeys", Request.Form["noOfMonkeys"]);

            return View();
        }

        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplayStudent(Student student)
        {
            if(string.IsNullOrEmpty(student.FirstName) ||  string.IsNullOrEmpty(student.LastName) || string.IsNullOrEmpty(student.EmailAddress) || string.IsNullOrEmpty(student.Desc) || string.IsNullOrEmpty(student.Password) || student.StudentId<=0)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(student);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
