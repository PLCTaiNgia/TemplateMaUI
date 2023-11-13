using TestContainerAPP.Models.ViewModels.Startup;

namespace TestContainerAPP.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel loginPageViewModel)
    {
        InitializeComponent();
        this.BindingContext = loginPageViewModel;
    }
}