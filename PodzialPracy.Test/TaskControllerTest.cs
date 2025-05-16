using Microsoft.AspNetCore.Mvc;
using Moq;
using PodzialPracy.Server.Controllers;
using PodzialPracy.Server.Repozytoria;
using PodzialPracy.Server.Serwis;

namespace PodzialPracy.Test
{
    public class TaskControllerTest
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly TaskController _taskController;


        public TaskControllerTest()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            var taskService = new TaskSerwice(_taskRepositoryMock.Object);
            _taskController = new TaskController(taskService);
        }

        [Fact]
        public void GetAllTasks_ReturnsOkResult()
        {
            var expectedTasks = new List<PodzialPracy.Server.Modele.Task>();
            _taskRepositoryMock.Setup(repo => repo.GetAllTasks()).Returns(expectedTasks);


            var result = _taskController.GetAllTasks();

            Assert.IsType<OkObjectResult>(result);
        }

    }
}
