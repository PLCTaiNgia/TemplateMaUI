using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestContainerAPP.Dto;
using TestContainerAPP.Pages;
using TestContainerAPP.Services.AuthService;

namespace TestContainerAPP.Models.ViewModels.Startup
{
    public partial class ChangePasswordPageViewModel : BaseViewModel
    {

        private readonly IAuthService authService;
        public ChangePasswordPageViewModel(IAuthService authService)
        {
            this.authService = authService;
        }

        [ObservableProperty]
        private string oldPassword;

        [ObservableProperty]
        private string newPassword;

        [ObservableProperty]
        private string confirmNewPassword;

        [RelayCommand]
        async Task RedirectToBack()
        {
            await Shell.Current.GoToAsync($"//{nameof(ContainerPage)}");
        }

        [RelayCommand]
        async Task ChangePassword()
        {
            var changePassword = new ChangePasswordRequestDto
            {
                OldPassword = OldPassword,
                NewPassword = NewPassword,
                ConfirmNewPassword = ConfirmNewPassword
            };

            var isChanged = await this.authService.ChangePassword(changePassword);
            if (isChanged)
            {
                OldPassword = "";
                NewPassword = "";
                ConfirmNewPassword = "";
                await Shell.Current.GoToAsync($"//{nameof(ContainerPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Đổi mật khẩu thất bại", "OK");
            }
        }
    }
}
