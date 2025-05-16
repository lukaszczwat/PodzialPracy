using PodzialPracy.Server.Enum;
using TaskStatus = PodzialPracy.Server.Enum.TaskStatus;

namespace PodzialPracy.Server.Modele
{
    /// <summary>
    /// Przedstawia zadanie w systemie.
    /// Zawiera informacje o treści, skali trudności, rodzaju i statusie zadania.
    /// </summary>
    public class Task
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public int SkalaTrudnosci { get; set; }
        public TaskType Rodzaj { get; set; }
        public TaskStatus Status { get; set; }


    }
}
