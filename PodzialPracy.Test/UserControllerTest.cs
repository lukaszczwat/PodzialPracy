using Microsoft.AspNetCore.Mvc;
using Moq;
using PodzialPracy.Server.Controllers;
using PodzialPracy.Server.Modele;
using PodzialPracy.Server.Repozytoria;
using PodzialPracy.Server.Serwis;

namespace PodzialPracy.Test
{
    public class UserControllerTest
    {

        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserController _userController;

        public UserControllerTest()
        {

            _userRepositoryMock = new Mock<IUserRepository>();
            var userService = new UserService(_userRepositoryMock.Object);
            _userController = new UserController(userService);
        }

        [Fact]
        public void GetAllUsers_ReturnsOkResult_WithUserList()
        {
            var expectedUsers = new List<User> { new User(), new User() };
            _userRepositoryMock.Setup(repo => repo.GetAllUsers()).Returns(expectedUsers);

            var result = _userController.GetAllUsers();

            Assert.IsType<OkObjectResult>(result);
        }

    }
}
