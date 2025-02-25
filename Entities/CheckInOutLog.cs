using System.ComponentModel.DataAnnotations;

namespace ChangePond_Visitors_Backend_Application.Entities
{
    public class CheckInOutLog
    {
        [Key]
        public int LogID { get; set; }
        public int VisitorID { get; set; }
        public string Action { get; set; } // Check-in / Check-out
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public virtual Visitor Visitor { get; set; }
    }
}
