using System.ComponentModel.DataAnnotations;

namespace ChangePond_Visitors_Backend_Application.Entities
{
    public class Visitor
    {
        [Key]
        public int VisitorID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Purpose { get; set; }
        public int HostID { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string? QRCode { get; set; }
        public string Status { get; set; } = "Pending"; // Pending, Checked-In, Checked-Out
        public string IDProof { get; set; }
        public string? OTP { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual Host Host { get; set; }
        public virtual ICollection<CheckInOutLog> CheckInOutLogs { get; set; }
    }
}
