using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.DTOs
{
    public class OrderCreateDto
    {
        [Required]
        public Guid ShippingAddressId { get; set; }
    }
}
