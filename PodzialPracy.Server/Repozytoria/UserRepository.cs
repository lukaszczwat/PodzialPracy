using PodzialPracy.Server.Data;
using PodzialPracy.Server.Modele;

namespace PodzialPracy.Server.Repozytoria
{
    public interface IUserRepository
    {
        IEnumerable<Modele.User> GetAllUsers();
     

    }

    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = DataMock.GetMockUsers();
        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }
    }
}
