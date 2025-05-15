using PodzialPracy.Server.Repozytoria;

namespace PodzialPracy.Server.Serwis
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<Modele.User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

    }
}
