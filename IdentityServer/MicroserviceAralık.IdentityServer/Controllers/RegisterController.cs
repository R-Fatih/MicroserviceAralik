using System.Threading.Tasks;
using MicroserviceAralık.IdentityServer.Dtos;
using MicroserviceAralık.IdentityServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MicroserviceAralık.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.Username,
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, result.Errors);
            return Ok("User created successfully");
        }
    }
}
