using Microsoft.AspNetCore.Mvc;

namespace MVC_Layouts_Case_study.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Admin")]
        public IActionResult AdminLogin()
        {
            return RedirectToAction("Dashboard", "Admin");
        }

        [Route("Trainer")]
        public IActionResult TrainerLogin()
        {
            return RedirectToAction("Dashboard", "Trainer");
        }

        [Route("Learner")]
        public IActionResult LearnerLogin()
        {
            return RedirectToAction("Dashboard", "Learner");
        }
    }
}
