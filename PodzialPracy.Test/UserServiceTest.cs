using Moq;
using PodzialPracy.Server.Enum;
using PodzialPracy.Server.Modele;
using PodzialPracy.Server.Repozytoria;
using PodzialPracy.Server.Serwis;

namespace PodzialPracy.Test
{
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;

        public UserServiceTest()
        {
            this._userRepositoryMock = new Mock<IUserRepository>();
            this._userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]
        public void GetUsers_ReturnsUserList()
        {
            var mockUsers = new List<User> { new User { Id = 1, Imie = "Jan", Nazwisko = "Kowalski", Typ = UserType.Programista } };
            _userRepositoryMock.Setup(repo => repo.GetAllUsers()).Returns(mockUsers);

            var result = _userService.GetAllUsers();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("Kowalski", result.First().Nazwisko);
        }

    }
}
