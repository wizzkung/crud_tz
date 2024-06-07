using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud_tz.Data;
using crud_tz.Models;

namespace crud_tz.Pages.ReturnedBooks
{
    public class EditModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public EditModel(crud_tz.Data.crud_tzContext context)
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

            var returned_books =  await _context.returnedBooks.FirstOrDefaultAsync(m => m.id == id);
            if (returned_books == null)
            {
                return NotFound();
            }
            Returned_Books = returned_books;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Returned_Books).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Returned_BooksExists(Returned_Books.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Returned_BooksExists(int id)
        {
          return (_context.returnedBooks?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
