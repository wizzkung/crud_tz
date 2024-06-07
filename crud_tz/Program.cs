using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using crud_tz.Data;
namespace crud_tz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<crud_tzContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("crud_tzContext") ?? throw new InvalidOperationException("Connection string 'crud_tzContext' not found.")));

            builder.Services.AddRazorPages();
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

          
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
             
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllers();

            app.MapControllerRoute(
              name: "UserRoute",
              pattern: "User/{action=Index}/{id?}",
              defaults: new { controller = "UserController" });

            app.MapControllerRoute(
                name: "BooksRoute",
                pattern: "Books/{action=Index}/{id?}",
                defaults: new { controller = "BookController" });

            app.MapControllerRoute(
                name: "ReturnedBooksRoute",
                pattern: "ReturnedBooks/{action=Index}/{id?}",
                defaults: new { controller = "ReturnedController" });

            app.MapControllerRoute(
                name: "BookIssuesRoute",
                pattern: "BookIssues/{action=Index}/{id?}",
                defaults: new { controller = "BookIssue" });

            app.MapControllerRoute(
                name: "PopularRoute",
                pattern: "Popular/{action=Index}/{id?}",
                defaults: new { controller = "popularController" });
            

            app.Run();
        }
    }
}