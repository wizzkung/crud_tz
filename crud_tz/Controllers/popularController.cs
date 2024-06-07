using crud_tz.Data;
using crud_tz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_tz.Controllers
{
    public class popularController : Controller
    {
        private readonly crud_tzContext _context;
        public popularController(crud_tzContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<IActionResult> Index()
        {
            var popular = await _context.book_issues
                .GroupBy(b => b.book_id).Select(g => new { id = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count).FirstOrDefaultAsync();

            if (popular != null)
            {
                var book = await _context.books.FindAsync(popular.id);
                return View(book);
            }

            return NotFound();
        }

    }
    }