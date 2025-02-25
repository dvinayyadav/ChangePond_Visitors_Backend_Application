using System.ComponentModel.DataAnnotations;

namespace ChangePond_Visitors_Backend_Application.Entities
{
    public class Host
    {
        [Key]
        public int HostID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Department { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
