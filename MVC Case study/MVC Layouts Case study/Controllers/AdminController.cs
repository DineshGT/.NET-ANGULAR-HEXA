using Microsoft.AspNetCore.Mvc;

namespace MVC_Layouts_Case_study.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [Route("Dashboard")]
        public IActionResult Dashboard() => View();

        [Route("UpdateProfile")]
        public IActionResult UpdateProfile() => View();

        [Route("Courses")]
        public IActionResult ManageCourses() => View();

        [Route("Trainers")]
        public IActionResult ManageTrainers() => View();

        [Route("Learners")]
        public IActionResult ManageLearners() => View();

        [Route("Logout")]
        public IActionResult Logout() => RedirectToAction("Index", "Home");
    }
}
