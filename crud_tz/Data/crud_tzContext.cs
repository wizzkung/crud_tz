using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crud_tz.Models;

namespace crud_tz.Data
{
    public class crud_tzContext : DbContext
    {
        public crud_tzContext(DbContextOptions<crud_tzContext> options) : base(options) { }

        public DbSet<Book> books { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Book_issue> book_issues { get; set; }
        public DbSet<Returned_Books> returnedBooks { get; set; }
        public DbSet<UnreturnedBook> unreturnedBooks { get; set; }
    }
}
