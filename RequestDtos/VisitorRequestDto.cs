namespace ChangePond_Visitors_Backend_Application.RequestDtos
{
    public class VisitorRequestDto
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Purpose { get; set; }
        public int HostID { get; set; }
        public string IDProof { get; set; }
    }
}
