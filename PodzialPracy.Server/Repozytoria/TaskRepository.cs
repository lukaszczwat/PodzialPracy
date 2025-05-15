
using PodzialPracy.Server.Data;

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
        public IEnumerable<Modele.Task> GetAllTasks()
        {
            return _tasks.Where(t => t.Status == Enum.TaskStatus.DoWykonania)
                .OrderByDescending(t => t.SkalaTrudnosci)
                .Take(10);
        }

        public IEnumerable<Modele.Task> GetTasksByUser(int userId)
        {
            return _tasks.Where(t => t.Status == Enum.TaskStatus.DoWykonania && t.Id == userId)
                .OrderByDescending(t => t.SkalaTrudnosci)
                .Take(10);
        }

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
