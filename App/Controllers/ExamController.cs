using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ExamController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Add", "Exam");
        }

        public IActionResult Add()
        {
            ViewBag.Login = true;
            return View();
        }

        public IActionResult List()
        {
            ViewBag.Login = true;
            return View();
        }

        public IActionResult Get(int id)
        {
            ViewBag.Id = id;
            ViewBag.Login = true;
            return View();
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Id = id;
            ViewBag.Login = true;
            return View();
        }
    }
}
