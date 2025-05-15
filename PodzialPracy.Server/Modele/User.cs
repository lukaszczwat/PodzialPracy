using PodzialPracy.Server.Enum;

namespace PodzialPracy.Server.Modele
{
    public class User
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public UserType Typ { get; set; }

    }
}
