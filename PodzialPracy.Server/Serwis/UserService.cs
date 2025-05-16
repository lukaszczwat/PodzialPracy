using PodzialPracy.Server.Repozytoria;

/// <summary>
/// Serwis do zarządzania użytkownikami.
/// </summary>
namespace PodzialPracy.Server.Serwis
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Inicjalizuje serwis `UserService` z repozytorium użytkowników.
        /// </summary>
        /// <param name="userRepository">Instancja repozytorium użytkowników</param>
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Pobiera listę wszystkich użytkowników w systemie.
        /// </summary>
        /// <returns>Lista użytkowników</returns>
        public IEnumerable<Modele.User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

    }
}
