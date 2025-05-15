using Microsoft.AspNetCore.Mvc;
using Moq;
using PodzialPracy.Server.Controllers;
using PodzialPracy.Server.Serwis;

namespace PodzialPracy.Test
{
    public class TaskControllerTest
    {
        private readonly Mock<TaskSerwice> _taskServiceMock;
        private readonly TaskController _taskController;


        public TaskControllerTest()
        {
            this._taskServiceMock = new Mock<TaskSerwice>();
            this._taskController = new TaskController(_taskServiceMock.Object);
        }

        [Fact]
        public void GetAllTasks_ReturnsOkResult()
        {
            _taskServiceMock.Setup(service => service.GetAllTasks()).Returns(new List<Server.Modele.Task>());

            var result = _taskController.GetAllTasks();

            Assert.IsType<OkObjectResult>(result);
        }

    }
}
