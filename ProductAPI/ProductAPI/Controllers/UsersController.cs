using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Entities;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);

        }

        // /api/users/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(int id)
        {
            var user = await context.Users.FindAsync(id);
            return user == null ?
                (ActionResult<IEnumerable<AppUser>>)NotFound() :
                (ActionResult<IEnumerable<AppUser>>)Ok(user);
        }
    }
}
