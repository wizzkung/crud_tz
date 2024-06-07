using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using crud_tz.Data;
using crud_tz.Models;

namespace crud_tz.Pages.issue
{
    public class DetailsModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public DetailsModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

      public Book_issue Book_issue { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.book_issues == null)
            {
                return NotFound();
            }

            var book_issue = await _context.book_issues.FirstOrDefaultAsync(m => m.id == id);
            if (book_issue == null)
            {
                return NotFound();
            }
            else 
            {
                Book_issue = book_issue;
            }
            return Page();
        }
    }
}
