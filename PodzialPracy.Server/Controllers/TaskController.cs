using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PodzialPracy.Server.Serwis;
using PodzialPracy.Server.Transfer;
using System.Text.Json;

namespace PodzialPracy.Server.Controllers
{
    /// <summary>
    /// Kontroler API do zarządzania zadaniami.
    /// Odpowiada za pobieranie i przypisywanie zadań użytkownikom.
    /// </summary>

    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskSerwice _taskService;

        /// <summary>
        /// Inicjalizuje kontroler z serwisem zadań.
        /// </summary>
        /// <param name="taskService">Instancja serwisu zadań</param>
        /// 

        public TaskController(TaskSerwice taskService)
        {
            _taskService = taskService;
        }


        /// <summary>
        /// Pobiera dostępne zadania do przypisania.
        /// </summary>
        /// <returns>Lista dostępnych zadań</returns>
        [HttpGet("GetAllTasks")]
        public IActionResult GetAllTasks(int page = 1, int pageSize = 10)
        {
            Console.WriteLine($"GetAllTasks() — page: {page}, pageSize: {pageSize}");
            Console.WriteLine("Wejście do GetAllTasks");

            try
            {
                var tasks = _taskService.GetAllTasks(page, pageSize);
                Console.WriteLine($"Zwracane zadania: {tasks.Count()}");
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd serializacji lub wykonania: " + ex.Message);
                return BadRequest("Błąd podczas pobierania zadań.");
            }
        }

        /// <summary>
        /// Pobiera listę zadań przypisanych do danego użytkownika.
        /// </summary>
        /// <returns>Lista dostępnych zadań</returns>

        [HttpGet("GetTasksByUser/{userId}")]
        public IActionResult GetTasksByUser(int userId)
        {
            var tasks = _taskService.GetTasksByUser(userId);
            return Ok(tasks);
        }

        /// <summary>
        /// Przypisuje użytkownikowi podaną listę zadań.
        /// Waliduje liczbę zadań i ich typy przed przypisaniem.
        /// </summary>

        [HttpPost("PrzypisanieTask/{userId}")]
        public IActionResult PrypisanieTask(int userId, [FromBody] PrzypisanieTask przypisanieTask)
        {
            try
            {
                Console.WriteLine("Otrzymany payload: " + JsonSerializer.Serialize(przypisanieTask));
                var result = _taskService.PrypisanieTask(przypisanieTask.UserId, przypisanieTask.Tasks);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd przy przypisaniu: " + ex.ToString()); 
                return BadRequest(ex.Message);
            }
        }

    }
}
