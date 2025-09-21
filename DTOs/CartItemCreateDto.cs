using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.DTOs
{
    public class CartItemCreateDto
    {
        [Required]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
