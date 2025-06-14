using Microsoft.AspNetCore.Mvc;
using Book_Model_Validation_Case_study.Models;
using System.Collections.Generic;
using System.Linq;


namespace BookValidationApp.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>();

        [Route("book-list")]
        public IActionResult List()
        {
            return View("BookList", books);
        }

        [HttpGet]
        [Route("add-book")]
        public IActionResult Add()
        {
            return View("AddBook");
        }

        [HttpPost]
        [Route("add-book")]
        public IActionResult Add(Book book)
        {
            if (ModelState.IsValid)
            {
                if (books.Any(b => b.Isbn == book.Isbn))
                {
                    ModelState.AddModelError("Isbn", "ISBN must be unique.");
                    return View("AddBook", book);
                }

                books.Add(book);
                return RedirectToAction("List");
            }

            return View("AddBook", book);
        }
    }
}
