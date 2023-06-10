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
            //ViewBag.noOfMonkeys = Request.Form["noOfMonkeys"];
            HttpContext.Session.SetString("noOfMonkeys", Request.Form["noOfMonkeys"]);

            return View();
        }

        public IActionResult CreateStudent() => View();

       /* [HttpPost]
        public IActionResult DisplayStudent(Student student)
        {
            // you will complete this
        }*/
        public IActionResult Error()
        {
            return View();
        }
    }
}
