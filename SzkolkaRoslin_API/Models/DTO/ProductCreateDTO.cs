using System.ComponentModel.DataAnnotations;

namespace SzkolkaRoslin_API.Models.DTO
{
    public class ProductCreateDTO 
    {
        [MaxLength(50)]
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        
    }
}
