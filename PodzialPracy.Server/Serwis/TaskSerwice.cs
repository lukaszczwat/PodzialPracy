using PodzialPracy.Server.Repozytoria;

/// <summary>
/// Serwis do zarządzania zadaniami użytkowników.
/// </summary>

namespace PodzialPracy.Server.Serwis
{
    public class TaskSerwice
    {

        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// Inicjalizuje serwis `TaskService` z repozytorium zadań.
        /// </summary>
        /// <param name="taskRepository">Instancja repozytorium zadań</param>
        /// 
        public TaskSerwice(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }

        /// <summary>
        /// Pobiera listę dostępnych zadań do przypisania.
        /// </summary>
        /// <returns>Lista dostępnych zadań</returns>
        public IEnumerable<Modele.Task> GetAllTasks(int page, int pageSize)
        {
            return _taskRepository.GetAllTasks(page, pageSize);
        }

        /// <summary>
        /// Pobiera listę przypisanych zadań dla danego użytkownika.
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <returns>Lista przypisanych zadań</returns>
        public IEnumerable<Modele.Task> GetTasksByUser(int userId)
        {
            return _taskRepository.GetTasksByUser(userId);
        }

        /// <summary>
        /// Przypisuje zadania użytkownikowi, sprawdzając warunki biznesowe.
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <param name="tasks">Lista zadań do przypisania</param>
        /// <returns>True jeśli przypisanie się powiodło, False w przeciwnym razie</returns>
        /// <exception cref="ArgumentException">Błąd walidacji liczby zadań</exception>

        public bool PrypisanieTask(int userId, List<Modele.Task> tasks)
        {
            if (tasks == null || tasks.Count < 5 || tasks.Count > 11)
                throw new ArgumentException("Liczba zadań do przypisania musi być pomiędzy 5 a 11.");

            int trudne = tasks.Count(t => t.SkalaTrudnosci >= 4);
            int latwe = tasks.Count(t => t.SkalaTrudnosci <= 2);

            double procentTrudne = (double)trudne / tasks.Count;
            double procentLatwe = (double)latwe / tasks.Count;

            if (procentTrudne < 0.1 || procentTrudne > 0.3)
                throw new ArgumentException("Nieprawidłowa liczba trudnych zadań (10–30%).");

            if (procentLatwe > 0.5)
                throw new ArgumentException("Nieprawidłowa liczba łatwych zadań (maks. 50%).");

            Console.WriteLine($"Otrzymano {tasks.Count} zadań do przypisania.");

            // Przypisz zadania
            foreach (var task in tasks)
            {
                var existing = _taskRepository.GetTaskById(task.Id);
                if (existing == null)
                {
                    Console.WriteLine($"Zadanie {task.Id} nie istnieje.");
                    continue;
                }

                if (existing.Status != Enum.TaskStatus.DoWykonania)
                {
                    Console.WriteLine($"Zadanie {existing.Id} ma status {existing.Status}, nie można przypisać.");
                    continue;
                }

                existing.Status = Enum.TaskStatus.Wykonane;
                existing.UserId = userId;

                if (task.TerminWdrozenia.HasValue)
                    existing.TerminWdrozenia = task.TerminWdrozenia;

                Console.WriteLine($"Przypisano zadanie {existing.Id} do użytkownika {userId}");
            }

            return true;
        }




    }
}
