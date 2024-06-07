using crud_tz.Data;
using crud_tz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_tz.Controllers
{

    public class BooksController : ControllerBase
    {
        private readonly crud_tzContext _context;

        public BooksController(crud_tzContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.books.ToList();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            _context.books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { id = book.id }, book);
        }

        [HttpGet("book/{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book book)
        {
            if (id != book.id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
