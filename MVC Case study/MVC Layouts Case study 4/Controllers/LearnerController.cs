using Microsoft.AspNetCore.Mvc;

namespace MVC_Layouts_Case_study.Controllers
{
    [Route("Learner")]
    public class LearnerController : Controller
    {
        [Route("Dashboard")]
        public IActionResult Dashboard() => View();

        [Route("UpdateProfile")]
        public IActionResult UpdateProfile() => View();

        [Route("SearchContent")]
        public IActionResult SearchContent() => View();

        [Route("Logout")]
        public IActionResult Logout() => RedirectToAction("Index", "Home");
    }
}
