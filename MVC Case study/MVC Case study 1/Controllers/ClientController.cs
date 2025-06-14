using Microsoft.AspNetCore.Mvc;
using MVC_Case_study_1.Models;


namespace MVC_Case_study_1.Controllers
{
    [Route("client")]
    public class ClientController : Controller
    {
        private static List<ClientInfo> clientList = new List<ClientInfo>();


        [Route("")]
        [Route("all")]
        public IActionResult ShowAllClientDetails()
        {
            return View(clientList);
        }

        [Route("byid/{id}")]
        public IActionResult GetDetailsByClientId(int id)
        {
            var client = clientList.FirstOrDefault(c => c.ClientId == id);
            return View("ClientDetails", client);
        }

        [Route("byname/{name}")]
        public IActionResult GetDetailsByCompanyName(string name)
        {
            var client = clientList.FirstOrDefault(c => c.CompanyName.ToLower() == name.ToLower());
            return View("ClientDetails", client);
        }


        [Route("byemail/{email}")]
        public IActionResult GetDetailsByEmail(string email)
        {
            var client = clientList.FirstOrDefault(c => c.Email.ToLower() == email.ToLower());
            return View("ClientDetails", client);
        }

        [Route("bycategory/{category}")]
        public IActionResult GetDetailsByCategory(string category)
        {
            var client = clientList.FirstOrDefault(c => c.Category.ToLower() == category.ToLower());
            return View("ClientDetails", client);
        }

        [Route("bystandard/{standard}")]
        public IActionResult GetDetailsByStandard(string standard)
        {
            var client = clientList.FirstOrDefault(c => c.Standard.ToLower() == standard.ToLower());
            return View("ClientDetails", client);
        }

        // to add a new client..

        [HttpGet]
        [Route("add")]
        public IActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddClient(ClientInfo clientInfo)
        {
            clientList.Add(clientInfo);
            return RedirectToAction("ShowAllClientDetails");
        }
    }
}
