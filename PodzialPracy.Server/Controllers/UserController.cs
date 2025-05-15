using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PodzialPracy.Server.Serwis;

namespace PodzialPracy.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }


    }
}
