using PodzialPracy.Server.Enum;
using System.Text.Json.Serialization;

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

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserType Typ { get; set; }
                
    }
}
