using crud_tz.Data;
using crud_tz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_tz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookIssuesController : ControllerBase
    {
        private readonly crud_tzContext _context;

        public BookIssuesController(crud_tzContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateBookIssue(Book_issue bookIssue)
        {
            // Проверяем, доступна ли книга для выдачи
            var book = _context.books.Find(bookIssue.book_id);
            if (book == null || book.quantity <= 0)
            {
                return BadRequest("Книга недоступна для выдачи");
            }

            // Проверяем, есть ли уже не закрытая выдача для этой книги
            var existingIssue = _context.book_issues
                .FirstOrDefault(b => b.book_id == bookIssue.book_id && b.return_date == null);
            if (existingIssue != null)
            {
                return BadRequest("Для этой книги уже есть открытая выдача");
            }

            // Создаем новую выдачу
            book.quantity--; // Уменьшаем количество доступных книг
            bookIssue.issue_date = DateTime.Now;
            _context.book_issues.Add(bookIssue);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBookIssue), new { id = bookIssue.id }, bookIssue);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookIssue(int id)
        {
            var bookIssue = _context.book_issues.Find(id);
            if (bookIssue == null)
            {
                return NotFound();
            }
            return Ok(bookIssue);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookIssue(int id, Book_issue bookIssue)
        {
            if (id != bookIssue.id)
            {
                return BadRequest();
            }

            _context.Entry(bookIssue).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookIssue(int id)
        {
            var bookIssue = _context.book_issues.Find(id);
            if (bookIssue == null)
            {
                return NotFound();
            }

            _context.book_issues.Remove(bookIssue);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
