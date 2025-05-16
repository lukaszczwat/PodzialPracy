using PodzialPracy.Server.Enum;

namespace PodzialPracy.Server.Modele
{
    /// <summary>
    /// Zawiera informacje o użytkowniku systemu.
    /// Przechowuje dane osobowe oraz typ użytkownika.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public UserType Typ { get; set; }

    }
}
