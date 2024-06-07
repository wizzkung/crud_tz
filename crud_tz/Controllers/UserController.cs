using crud_tz.Data;
using crud_tz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud_tz.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly crud_tzContext _context;

        public UserController(crud_tzContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.users.ToList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUser), new { id = user.id }, user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            if (id != user.id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
