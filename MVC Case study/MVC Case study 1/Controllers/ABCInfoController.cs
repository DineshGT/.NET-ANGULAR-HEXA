using Microsoft.AspNetCore.Mvc;
using MVC_Case_study_1.Models;

namespace MVC_Case_study_1.Controllers
{
    public class ABCInfoController : Controller
    {
        // to create a list (ABCInfotect contact info.. object)
        static List<Contact> contactList = new List<Contact>();

        public IActionResult ShowContacts()
        {
            return View(contactList);
        }


        // to get contact using ID

        public IActionResult GetContactById(int id)
        {
            var contact = contactList.FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        // to add contact details form using get method..
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        // to save the added contact in server using post method..
        [HttpPost]
        public IActionResult AddContact(Contact contactInfo)
        {
            contactList.Add(contactInfo);
            return RedirectToAction("ShowContacts");
        }

    }
}
