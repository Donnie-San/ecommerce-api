using ECommerce.Api.Data;
using ECommerce.Api.DTOs;
using ECommerce.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ECommerce.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShippingAddressController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ShippingAddressController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingAddressReadDto>>> GetAll()
        {
            var userId = GetUserId();
            var addresses = await _context.ShippingAddresses
                .Where(sa => sa.UserId == userId)
                .ToListAsync();

            var result = addresses.Select(sa => new ShippingAddressReadDto {
                Id = sa.Id,
                Street = sa.Street,
                City = sa.City,
                PostalCode = sa.PostalCode,
                Country = sa.Country
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ShippingAddressCreateDto dto)
        {
            var userId = GetUserId();

            var address = new ShippingAddress {
                UserId = userId,
                Street = dto.Street,
                City = dto.City,
                PostalCode = dto.PostalCode,
                Country = dto.Country
            };

            _context.ShippingAddresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), null);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, ShippingAddressUpdateDto dto)
        {
            var userId = GetUserId();
            var address = await _context.ShippingAddresses
                .FirstOrDefaultAsync(sa => sa.Id == id && sa.UserId == userId);

            if (address == null) return NotFound();

            address.Street = dto.Street;
            address.City = dto.City;
            address.PostalCode = dto.PostalCode;
            address.Country = dto.Country;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var userId = GetUserId();
            var address = await _context.ShippingAddresses
                .FirstOrDefaultAsync(sa => sa.Id == id && sa.UserId == userId);

            if (address == null) return NotFound();

            _context.ShippingAddresses.Remove(address);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private Guid GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            return Guid.Parse(userIdClaim.Value);
        }
    }
}
