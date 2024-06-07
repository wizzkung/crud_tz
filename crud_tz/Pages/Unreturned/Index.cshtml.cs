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
    public class IndexModel : PageModel
    {
        private readonly crud_tz.Data.crud_tzContext _context;

        public IndexModel(crud_tz.Data.crud_tzContext context)
        {
            _context = context;
        }

        public IList<UnreturnedBook> UnreturnedBook { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.unreturnedBooks != null)
            {
                UnreturnedBook = await _context.unreturnedBooks.ToListAsync();
            }
        }
    }
}
