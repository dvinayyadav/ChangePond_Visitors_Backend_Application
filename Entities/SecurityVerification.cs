using System.ComponentModel.DataAnnotations;

namespace ChangePond_Visitors_Backend_Application.Entities
{
    public class SecurityVerification
    {
        [Key]
        public int VerificationID { get; set; }
        public int VisitorID { get; set; }
        public string OTP { get; set; }
        public bool OTPVerified { get; set; } = false;
        public string IDProof { get; set; } // File path of uploaded ID
        public DateTime? VerifiedAt { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
