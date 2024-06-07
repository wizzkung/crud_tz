using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud_tz.Data;
using crud_tz.Models;

namespace crud_tz.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public DeleteModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }

            var book = await _context.books.FirstOrDefaultAsync(m => m.id == id);

            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.books == null)
            {
                return NotFound();
            }
            var book = await _context.books.FindAsync(id);

            if (book != null)
            {
                Book = book;
                _context.books.Remove(Book);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
