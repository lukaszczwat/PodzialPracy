using PodzialPracy.Server.Repozytoria;

namespace PodzialPracy.Server.Serwis
{
    public class TaskSerwice
    {

        private readonly ITaskRepository _taskRepository;
        public TaskSerwice(ITaskRepository taskRepository)
        {
            this._taskRepository = taskRepository;
        }
        public IEnumerable<Modele.Task> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }
        public IEnumerable<Modele.Task> GetTasksByUser(int userId)
        {
            return _taskRepository.GetTasksByUser(userId);
        }
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
