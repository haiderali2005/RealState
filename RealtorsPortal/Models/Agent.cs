using System.ComponentModel.DataAnnotations;

namespace RealtorsPortal.Models
{
    public class Agent
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; } 
        public List<Property> Properties { get; set; } 
    }
}
