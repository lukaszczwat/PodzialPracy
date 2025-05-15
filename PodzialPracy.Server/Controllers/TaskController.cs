using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PodzialPracy.Server.Serwis;
using PodzialPracy.Server.Transfer;

namespace PodzialPracy.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskSerwice _taskService;

        public TaskController(TaskSerwice taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("GetTasksByUser/{userId}")]
        public IActionResult GetTasksByUser(int userId)
        {
            var tasks = _taskService.GetTasksByUser(userId);
            return Ok(tasks);
        }

        [HttpPost("PrypisanieTask/{userId}")]
        public IActionResult PrypisanieTask(int userId, [FromBody] PrzypisanieTask przypisanieTask)
        {
            try
            {
                var result = _taskService.PrypisanieTask(przypisanieTask.UserId, przypisanieTask.Tasks);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
