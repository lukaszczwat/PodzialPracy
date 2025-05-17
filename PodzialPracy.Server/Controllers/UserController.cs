using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PodzialPracy.Server.Serwis;

namespace PodzialPracy.Server.Controllers
{
    /// <summary>
    /// Kontroler API do zarządzania użytkownikami.
    /// </summary>
    /// 

    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
       
        private readonly UserService _userService;

        /// <summary>
        /// Inicjalizuje kontroler z serwisem użytkowników.
        /// </summary>
        /// <param name="userService">Instancja serwisu użytkowników</param>
        /// 

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Pobiera listę wszystkich użytkowników.
        /// </summary>
        /// <returns>Lista użytkowników</returns>

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }


    }
}
