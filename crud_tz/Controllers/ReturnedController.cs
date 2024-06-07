using crud_tz.Data;
using crud_tz.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud_tz.Controllers
{
    public class ReturnedBookController : Controller
    {
        [ApiController]
        [Route("[controller]")]
        public class ReturnedBooksController : ControllerBase
        {
            private readonly crud_tzContext _context;

            public ReturnedBooksController(crud_tzContext context)
            {
                _context = context;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Returned_Books>> GetReturnedBooks()
            {
                return _context.returnedBooks.ToList();
            }

            [HttpGet("{id}")]
            public ActionResult<Returned_Books> GetReturnedBooks(int id)
            {
                var returnedBook = _context.returnedBooks.Find(id);

                if (returnedBook == null)
                {
                    return NotFound();
                }

                return returnedBook;
            }

            [HttpPost]
            public ActionResult<Returned_Books> PostReturnedBook(Returned_Books returnedBook)
            {
                _context.returnedBooks.Add(returnedBook);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetReturnedBooks), new { id = returnedBook.id }, returnedBook);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteReturnedBook(int id)
            {
                var returnedBook = _context.returnedBooks.Find(id);

                if (returnedBook == null)
                {
                    return NotFound();
                }

                _context.returnedBooks.Remove(returnedBook);
                _context.SaveChanges();

                return NoContent();
            }
        }
    }
}
