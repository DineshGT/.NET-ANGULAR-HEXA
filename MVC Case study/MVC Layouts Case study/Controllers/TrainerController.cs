using Microsoft.AspNetCore.Mvc;

namespace MVC_Layouts_Case_study.Controllers
{
    [Route("Trainer")]
    public class TrainerController : Controller
    {
        [Route("Dashboard")]
        public IActionResult Dashboard() => View();

        [Route("UpdateProfile")]
        public IActionResult UpdateProfile() => View();

        [Route("Content")]
        public IActionResult ManageContent() => View();

        [Route("Logout")]
        public IActionResult Logout() => RedirectToAction("Index", "Home");
    }
}
