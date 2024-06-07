using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud_tz.Data;
using crud_tz.Models;

namespace crud_tz.Pages.ReturnedBooks
{
    public class DeleteModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public DeleteModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Returned_Books Returned_Books { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.returnedBooks == null)
            {
                return NotFound();
            }

            var returned_books = await _context.returnedBooks.FirstOrDefaultAsync(m => m.id == id);

            if (returned_books == null)
            {
                return NotFound();
            }
            else 
            {
                Returned_Books = returned_books;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.returnedBooks == null)
            {
                return NotFound();
            }
            var returned_books = await _context.returnedBooks.FindAsync(id);

            if (returned_books != null)
            {
                Returned_Books = returned_books;
                _context.returnedBooks.Remove(Returned_Books);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
