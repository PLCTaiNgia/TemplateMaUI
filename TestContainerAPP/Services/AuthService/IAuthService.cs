using TestContainerAPP.Dto;

namespace TestContainerAPP.Services.AuthService
{
    public interface IAuthService
    {
        Task<bool> ChangePassword(ChangePasswordRequestDto changePasswordRequestDto);
        Task<bool> IsAuthenticatedAsync();
        Task<bool> LoginAsync(LoginRequestDto loginRequestDto);
        void LogoutAsync();
        Task<bool> RegisterAsync(RegisterRequestDto registerRequestDto);
    }
}
