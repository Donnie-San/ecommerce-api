using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.DTOs
{
    public class CategoryUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
