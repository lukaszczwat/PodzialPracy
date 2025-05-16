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
        public IEnumerable<Modele.Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
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

            if(tasks.Count <5 || tasks.Count > 11)
            {
                throw new ArgumentException("Liczba zadań do przypisania musi być pomiędzy 5 a 11.");
            }

            int wysokiPoziomTrudnosci = tasks.Count(t => t.SkalaTrudnosci >= 4);
            int niskiPoziomTrudnosci = tasks.Count(t => t.SkalaTrudnosci <= 2);


            if(wysokiPoziomTrudnosci <tasks.Count * 0.1 || wysokiPoziomTrudnosci >tasks.Count *0.3)
                throw new ArgumentException("Nieprawidłowa liczba trudnych zadań");

            if(niskiPoziomTrudnosci >tasks.Count * 0.5)
                throw new ArgumentException("Nieprawidłowa liczba łatwych zadań");


            return _taskRepository.PrypisanieTask(userId, tasks);
        }


    }
}
