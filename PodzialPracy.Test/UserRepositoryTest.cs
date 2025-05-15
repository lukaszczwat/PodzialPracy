
using PodzialPracy.Server.Repozytoria;

namespace PodzialPracy.Test
{
    public class UserRepositoryTest
    {

        private readonly UserRepository _userRepository;
        public UserRepositoryTest()
        {
            this._userRepository = new UserRepository();
        }

        [Fact]

        public void GetAllUsers_ReturnsUsers()
        {
            var users = _userRepository.GetAllUsers();
            Assert.NotNull(users);
            Assert.NotEmpty(users);
            Assert.True(users.Count() <= 10);
        }


    }
}
