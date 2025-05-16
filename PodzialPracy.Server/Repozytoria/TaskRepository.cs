using PodzialPracy.Server.Data;

/// <summary>
/// Repozytorium do zarządzania zadaniami.
/// </summary>
namespace PodzialPracy.Server.Repozytoria
{
    public interface ITaskRepository
    {
        IEnumerable<Modele.Task> GetAllTasks();
        IEnumerable<Modele.Task> GetTasksByUser(int userId);

        bool PrypisanieTask(int userId, List<Modele.Task> tasks);

    }

    public class TaskRepository : ITaskRepository
    {
        private List<Modele.Task> _tasks = DataMock.GetMockTasks();

        /// <summary>
        /// Pobiera zadania, które mogą być przypisane użytkownikowi.
        /// </summary>
        /// <returns>Lista dostępnych zadań</returns>
        public IEnumerable<Modele.Task> GetAllTasks()
        {
            return _tasks.Where(t => t.Status == Enum.TaskStatus.DoWykonania)
                .OrderByDescending(t => t.SkalaTrudnosci)
                .Take(10);
        }

        /// <summary>
        /// Pobiera zadania, które zostały przypisane danemu użytkownikowi.
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <returns>Lista przypisanych zadań</returns>
        public IEnumerable<Modele.Task> GetTasksByUser(int userId)
        {
            return _tasks.Where(t => t.Status == Enum.TaskStatus.DoWykonania && t.Id == userId)
                .OrderByDescending(t => t.SkalaTrudnosci)
                .Take(10);
        }


        /// <summary>
        /// Przypisuje użytkownikowi wybrane zadania.
        /// </summary>
        /// <param name="userId">Id użytkownika</param>
        /// <param name="tasks">Lista zadań do przypisania</param>
        /// <returns>True jeśli zadania zostały przypisane, False w przeciwnym razie</returns>

        public bool PrypisanieTask(int userId, List<Modele.Task> tasks)
        {
            foreach (var task in tasks)
            {
                if (_tasks.Any(t => t.Id == task.Id)) return false;
                {
                    task.Status = Enum.TaskStatus.Wykonane;
                }
            }

            return true;
        }
    }
}
