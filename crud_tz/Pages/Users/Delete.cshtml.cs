using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud_tz.Data;
using crud_tz.Models;

namespace crud_tz.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public DeleteModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

        [BindProperty]
      public User User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users.FirstOrDefaultAsync(m => m.id == id);

            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }
            var user = await _context.users.FindAsync(id);

            if (user != null)
            {
                User = user;
                _context.users.Remove(User);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
