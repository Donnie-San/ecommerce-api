using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.DTOs
{
    public class CategoryCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
