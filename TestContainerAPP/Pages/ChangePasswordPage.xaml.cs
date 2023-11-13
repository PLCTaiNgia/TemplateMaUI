using TestContainerAPP.Models.ViewModels.Startup;

namespace TestContainerAPP.Pages;

public partial class ChangePasswordPage : ContentPage
{
    public ChangePasswordPage(ChangePasswordPageViewModel changePasswordPageViewModel)
    {
        InitializeComponent();

        BindingContext = changePasswordPageViewModel;
    }
}