using System.ComponentModel.DataAnnotations;

namespace RealtorsPortal.Models
{
    public class Property
    {
        [Key]
        public int Property_Id { get; set; } 
        public string Name { get; set; } 
        public string Address { get; set; } 
        public string Image { get; set; } 
        public string Price { get; set; } 
        public int Bedrooms { get; set; } 
        public int Bathrooms { get; set; } 
        public int? Id { get; set; }
        public Agent Agent { get; set; } 
        public int? PrivateSellerId { get; set; }
        public PrivateSeller PrivateSeller { get; set; } 
    }
}
