using System.Linq;
using System.Threading.Tasks;
using MicroserviceAralık.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceAralık.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.Select(x => new
            {
                x.Id,
                x.UserName,
                x.Email
            }).ToListAsync();
            return Ok(users);
        }
    }
}
