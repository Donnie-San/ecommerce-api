using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.DTOs
{
    public class CartItemUpdateDto
    {
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
