using PodzialPracy.Server.Data;
using PodzialPracy.Server.Modele;

/// <summary>
/// Repozytorium do zarządzania użytkownikami.
/// </summary>
namespace PodzialPracy.Server.Repozytoria
{
    public interface IUserRepository
    {
        IEnumerable<Modele.User> GetAllUsers();
     

    }

    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = DataMock.GetMockUsers();

        /// <summary>
        /// Pobiera listę wszystkich użytkowników w systemie.
        /// </summary>
        /// <returns>Lista użytkowników</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }
    }
}
