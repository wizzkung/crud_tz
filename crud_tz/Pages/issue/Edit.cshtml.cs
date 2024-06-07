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

namespace crud_tz.Pages.issue
{
    public class EditModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public EditModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book_issue Book_issue { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.book_issues == null)
            {
                return NotFound();
            }

            var book_issue =  await _context.book_issues.FirstOrDefaultAsync(m => m.id == id);
            if (book_issue == null)
            {
                return NotFound();
            }
            Book_issue = book_issue;
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

            _context.Attach(Book_issue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Book_issueExists(Book_issue.id))
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

        private bool Book_issueExists(int id)
        {
          return (_context.book_issues?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
