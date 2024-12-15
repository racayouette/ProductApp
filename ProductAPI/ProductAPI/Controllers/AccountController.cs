using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.DTOs;
using ProductAPI.Entities;
using ProductAPI.SecretHasher;

namespace ProductAPI.Controllers
{
    public class AccountController(DataContext context) : BaseApiController
    {
        // api/account/register
        [HttpPost("register")] 
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("Username is taken");
            }

            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = ProtectPassword.Hash(registerDto.Password)
            };

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());
            if (user == null) 
            { 
                return Unauthorized("Invalid username or password"); 
            }

            if (!ProtectPassword.Verify(loginDto.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(user);
        }

        private async Task<bool> UserExists(string username)
        {
            return await context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()); // Bob != bob
        }
    }
}