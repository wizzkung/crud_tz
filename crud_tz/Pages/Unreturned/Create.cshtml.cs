using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using crud_tz.Data;
using crud_tz.Models;

namespace crud_tz.Pages.Unreturned
{
    public class CreateModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public CreateModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public UnreturnedBook UnreturnedBook { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.unreturnedBooks == null || UnreturnedBook == null)
            {
                return Page();
            }

            _context.unreturnedBooks.Add(UnreturnedBook);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
