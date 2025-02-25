using System.ComponentModel.DataAnnotations;

namespace ChangePond_Visitors_Backend_Application.Entities
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }
        public int VisitorID { get; set; }
        public int HostID { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending"; // Sent, Failed

        public virtual Visitor Visitor { get; set; }
        public virtual Host Host { get; set; }
    }
}
