namespace ChangePond_Visitors_Backend_Application.ResponseDtos
{
    public class VisitorResponseDto
    {
        public int VisitorID { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Purpose { get; set; }
        public int HostID { get; set; }
        public string HostName { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string QRCode { get; set; }
        public string Status { get; set; }
        public string IDProof { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
