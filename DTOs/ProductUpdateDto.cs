using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.DTOs
{
    public class ProductUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
    }
}
