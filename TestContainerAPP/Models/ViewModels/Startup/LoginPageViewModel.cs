using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestContainerAPP.Dto;
using TestContainerAPP.Pages;
using TestContainerAPP.Services.AuthService;

namespace TestContainerAPP.Models.ViewModels.Startup
{
    public partial class LoginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string password;

        [RelayCommand]
        async void Login()
        {
            var reqData = new LoginRequestDto { Password = Password, Username = UserName };

            AuthService authService = new AuthService();

            var loginSuccess = await authService.LoginAsync(reqData);

            if (loginSuccess)
            {
                await Shell.Current.GoToAsync($"//{nameof(ContainerPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Lỗi đăng nhập", "OK");
            }
        }

        [RelayCommand]
        async void RedirectToRegisterPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
    }
}
