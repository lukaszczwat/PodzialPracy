using PodzialPracy.Server.Repozytoria;

namespace PodzialPracy.Test
{
    public class TaskRepositoryTest
    {
        private readonly TaskRepository _taskRepository;

        public TaskRepositoryTest()
        {
            this._taskRepository = new TaskRepository();
        }

        [Fact]
        public void GetAllTasks_ReturnsTasks()
        {
            var tasks = _taskRepository.GetAllTasks();

            Assert.NotNull(tasks);
            Assert.True(tasks.Count() <= 10);
        }
    }
}