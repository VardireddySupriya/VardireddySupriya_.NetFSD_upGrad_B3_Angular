using backend_mini_project1.Models;

namespace backend_mini_project1.Services
{
    public interface IAuthService
    {
        Task<UserResponseDTO> RegisterAsync(RegisterDTO dto);

        Task<object> LoginAsync(LoginDTO dto);
    }
}
