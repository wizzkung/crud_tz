using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud_tz.Data;
using crud_tz.Models;

namespace crud_tz.Pages.Unreturned
{
    public class DetailsModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public DetailsModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

      public UnreturnedBook UnreturnedBook { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.unreturnedBooks == null)
            {
                return NotFound();
            }

            var unreturnedbook = await _context.unreturnedBooks.FirstOrDefaultAsync(m => m.id == id);
            if (unreturnedbook == null)
            {
                return NotFound();
            }
            else 
            {
                UnreturnedBook = unreturnedbook;
            }
            return Page();
        }
    }
}
