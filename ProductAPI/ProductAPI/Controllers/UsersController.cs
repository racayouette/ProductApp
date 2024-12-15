using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Entities;

namespace ProductAPI.Controllers
{
    public class UsersController(DataContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await context.Users.ToListAsync();
            return Ok(users);

        }

        // /api/users/1
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            var user = await context.Users.FindAsync(id);
            return user == null ?
                (ActionResult<AppUser>)NotFound() :
                (ActionResult<AppUser>)Ok(user);
        }
    }
}
