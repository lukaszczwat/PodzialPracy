using PodzialPracy.Server.Enum;
using TaskStatus = PodzialPracy.Server.Enum.TaskStatus;

namespace PodzialPracy.Server.Data
{
    public class DataMock
    {
        public static List<Modele.Task> GetMockTasks()
        {
            return new List<Modele.Task>
            {
                new Modele.Task
                {
                    Id = 1,
                    Tresc = "Implementacja API",
                    SkalaTrudnosci = 3,
                    Rodzaj = TaskType.Implementacja,
                    Status = TaskStatus.DoWykonania,
                },
                new Modele.Task
                {
                    Id = 2,
                    Tresc = "Wdrożenie aplikacji",
                    SkalaTrudnosci = 4,
                    Rodzaj = TaskType.Wdrożenie,
                    Status = TaskStatus.DoWykonania,


                },
                new Modele.Task
                {
                    Id = 3,
                    Tresc = "Utrzymanie systemu",
                    SkalaTrudnosci = 2,
                    Rodzaj = TaskType.Maintanance,
                    Status = TaskStatus.Wykonane,
                },
                new Modele.Task
                {
                    Id = 4,
                    Tresc = "Testowanie aplikacji",
                    SkalaTrudnosci = 5,
                    Rodzaj = TaskType.Implementacja,
                    Status = TaskStatus.DoWykonania,
                },
                new Modele.Task
                {
                    Id = 5,
                    Tresc = "Dokumentacja projektu",
                    SkalaTrudnosci = 1,
                    Rodzaj = TaskType.Maintanance,
                    Status = TaskStatus.Wykonane,
                },
                new Modele.Task
                {
                    Id = 6,
                    Tresc = "Szkolenie zespołu",
                    SkalaTrudnosci = 3,
                    Rodzaj = TaskType.Wdrożenie,
                    Status = TaskStatus.DoWykonania,
                },
                new Modele.Task
                {
                    Id = 7,
                    Tresc = "Przygotowanie prezentacji",
                    SkalaTrudnosci = 2,
                    Rodzaj = TaskType.Implementacja,
                    Status = TaskStatus.Wykonane,
                },
                new Modele.Task
                {
                    Id = 8,
                    Tresc = "Analiza wymagań",
                    SkalaTrudnosci = 4,
                    Rodzaj = TaskType.Maintanance,
                    Status = TaskStatus.DoWykonania,
                },
                new Modele.Task
                {
                    Id = 9,
                    Tresc = "Optymalizacja kodu",
                    SkalaTrudnosci = 5,
                    Rodzaj = TaskType.Implementacja,
                    Status = TaskStatus.Wykonane,
                },
                new Modele.Task
                {
                    Id = 10,
                    Tresc = "Zarządzanie projektem",
                    SkalaTrudnosci = 3,
                    Rodzaj = TaskType.Wdrożenie,
                    Status = TaskStatus.DoWykonania,
                },
                new Modele.Task
                {
                    Id = 11,
                    Tresc = "Przegląd kodu",
                    SkalaTrudnosci = 2,
                    Rodzaj = TaskType.Maintanance,
                    Status = TaskStatus.Wykonane,
                },
                new Modele.Task
                {
                    Id = 12,
                    Tresc = "Planowanie sprintu",
                    SkalaTrudnosci = 4,
                    Rodzaj = TaskType.Implementacja,
                    Status = TaskStatus.DoWykonania,
                },
                new Modele.Task
                {
                    Id = 13,
                    Tresc = "Zarządzanie ryzykiem",
                    SkalaTrudnosci = 5,
                    Rodzaj = TaskType.Wdrożenie,
                    Status = TaskStatus.Wykonane,
                },
                new Modele.Task
                {
                    Id = 14,
                    Tresc = "Integracja systemu",
                    SkalaTrudnosci = 3,
                    Rodzaj = TaskType.Maintanance,
                    Status = TaskStatus.DoWykonania,
                },
                new Modele.Task
                {
                    Id = 15,
                    Tresc = "Zarządzanie zespołem",
                    SkalaTrudnosci = 2,
                    Rodzaj = TaskType.Implementacja,
                    Status = TaskStatus.Wykonane,
                }
            };

        }

        public static List<Modele.User> GetMockUsers()
        {
            return new List<Modele.User>
            {
                new Modele.User
                {
                    Id = 1,
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    Typ = UserType.Programista,
                },
                new Modele.User
                {
                    Id = 2,
                    Imie = "Anna",
                    Nazwisko = "Nowak",
                    Typ = UserType.Programista,
                },
                new Modele.User
                {
                    Id = 3,
                    Imie = "Piotr",
                    Nazwisko = "Zalewski",
                    Typ = UserType.Administrator,
                },
                new Modele.User
                {
                    Id = 4,
                    Imie = "Katarzyna",
                    Nazwisko = "Wójcik",
                    Typ = UserType.Administrator,
                },
                new Modele.User
                {
                    Id = 5,
                    Imie = "Magdalena",
                    Nazwisko = "Kowalczyk",
                    Typ = UserType.Administrator,
                },
                new Modele.User
                {
                    Id = 6,
                    Imie = "Tomasz",
                    Nazwisko = "Lewandowski",
                    Typ = UserType.Programista,
                }

            };
        }
    }
}
