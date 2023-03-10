using Microsoft.AspNetCore.Mvc;
using MockUp.Application.Models;
using MockUp.Application.Services.Interfaces;

namespace MockUp.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] Users user)
        {
            var result = await _userServices.CreateUser(user);

            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserList(string userId)
        {
            var result = await _userServices.GetUserList(userId);

            return Ok(result);
        }

        [HttpDelete("{userId:int}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var result = await _userServices.DeleteUser(userId);

            return Ok(result);
        }
    }
}
