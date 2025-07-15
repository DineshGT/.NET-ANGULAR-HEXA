using SimplyFly.API.DTO.Models.Auth;
using SimplyFly.API.DTOs.Models.Auth;

namespace SimplyFly.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse?> RegisterAsync(RegisterRequest request);
        Task<AuthResponse?> LoginAsync(LoginRequest request);
    }

}
