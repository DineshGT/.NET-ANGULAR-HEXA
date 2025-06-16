using Microsoft.AspNetCore.Mvc;

namespace MVC_Layouts_Case_study.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]

        public IActionResult Index()
        {
            return View();
        }

        [Route("Home/Contact")]

        public IActionResult Contact()
        {
            return View();
        }

        [Route("Home/About")]

        public IActionResult About()
        {
            return View();
        }
    }
}
