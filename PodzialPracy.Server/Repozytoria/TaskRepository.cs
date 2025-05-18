using Microsoft.AspNetCore.Mvc.RazorPages;
using PodzialPracy.Server.Data;

/// <summary>
/// Repozytorium do zarządzania zadaniami.
/// </summary>
namespace PodzialPracy.Server.Repozytoria
{
    public interface ITaskRepository
    {
        IEnumerable<Modele.Task> GetAllTasks(int page, int pageSize);
        IEnumerable<Modele.Task> GetTasksByUser(int userId);
        Modele.Task? GetTaskById(int id);

        bool PrypisanieTask(int userId, List<Modele.Task> tasks);

    }

    public class TaskRepository : ITaskRepository
    {
        private List<Modele.Task> _tasks = DataMock.GetMockTasks();

        /// <summary>
        /// Pobiera zadania, które mogą być przypisane użytkownikowi.
        /// </summary>
        /// <returns>Lista dostępnych zadań</returns>
        public IEnumerable<Modele.Task> GetAllTasks(int page = 1, int pageSize = 10)
        {
            return _tasks
                .Where(t => t.Status == Enum.TaskStatus.DoWykonania && t.UserId == null)
                .OrderByDescending(t => t.SkalaTrudnosci)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        /// <summary>
        /// Pobiera zadania, które zostały przypisane danemu użytkownikowi.
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <returns>Lista przypisanych zadań</returns>
        public IEnumerable<Modele.Task> GetTasksByUser(int userId)
        {
            return _tasks
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.SkalaTrudnosci)
                .Take(10);
        }

        /// <summary>
        /// Przypisuje użytkownikowi wybrane zadania.
        /// </summary>


        public bool PrypisanieTask(int userId, List<Modele.Task> tasks)
        {
            foreach (var task in tasks)
            {
                var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
                if (existing == null)
                {
                    Console.WriteLine($"Zadanie o ID {task.Id} nie znalezione.");
                    continue;
                }

                if (existing.Status != Enum.TaskStatus.DoWykonania)
                {
                    Console.WriteLine($"Zadanie {existing.Id} już przypisane. Pomijam.");
                    continue;
                }

                existing.Status = Enum.TaskStatus.Wykonane;
                existing.UserId = userId;
                existing.TerminWdrozenia = task.TerminWdrozenia;

                Console.WriteLine($"Przypisano zadanie {existing.Id} do użytkownika {userId}");
            }


            return true;
        }


        public Modele.Task? GetTaskById(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }
    }
}
