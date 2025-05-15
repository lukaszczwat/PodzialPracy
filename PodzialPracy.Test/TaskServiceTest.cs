using Moq;
using PodzialPracy.Server.Repozytoria;
using PodzialPracy.Server.Serwis;
using System.Reflection;

namespace PodzialPracy.Test
{
    public class TaskServiceTest
    {

        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly TaskSerwice _taskService;

        public TaskServiceTest()
        {
            
            this._taskRepositoryMock = new Mock<ITaskRepository>();
            this._taskService = new TaskSerwice(_taskRepositoryMock.Object);

        }

        [Fact]
        public void a_GetAllTasks_ReturnsTasks()
        {
            // Arrange
            var mockTask = new List<Server.Modele.Task> { new Server.Modele.Task() { Id = 1, SkalaTrudnosci = 5, Status = Server.Enum.TaskStatus.DoWykonania} };
            _taskRepositoryMock.Setup(repo => repo.GetAllTasks()).Returns(mockTask);

            // Act
            var result = _taskService.GetAllTasks();

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(5, result.First().SkalaTrudnosci);
        }

        [Fact]
        public void b_PrzypiszTask_ThrowException()
        {
            var tasks = new List<Server.Modele.Task> { new Server.Modele.Task { Id = 1, SkalaTrudnosci = 5 } };

            Assert.Throws<ArgumentException>(() => _taskService.PrypisanieTask(1, tasks));
        }
    }
}
