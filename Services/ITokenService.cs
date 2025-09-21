using ECommerce.Api.Models;

namespace ECommerce.Api.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
