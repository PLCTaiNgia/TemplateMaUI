using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestContainerAPP.Dto;
using TestContainerAPP.Pages;
using TestContainerAPP.Services.AuthService;

namespace TestContainerAPP.Models.ViewModels.Startup
{
    public partial class RegisterPageViewModel : BaseViewModel
    {
        public RegisterPageViewModel(IAuthService authService)
        {
            this.authService = authService;
        }

        [ObservableProperty]
        private string fullName;

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string confirmPassword;

        public IAuthService authService { get; }

        [RelayCommand]
        async void RedirectToLoginPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        [RelayCommand]
        async void Register()
        {
            var registerDto = new RegisterRequestDto
            {
                FullName = FullName,
                Username = Username,
                Password = Password,
                ConfirmPassword = ConfirmPassword
            };
            var isRegister = await authService.RegisterAsync(registerDto);

            if (isRegister)
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Lỗi đăng ký vui lòng thử lại", "OK");
            }
        }
    }
}
