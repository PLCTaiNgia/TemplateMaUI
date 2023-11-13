using TestContainerAPP.Models.ViewModels.Startup;

namespace TestContainerAPP.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterPageViewModel registerPageViewModel)
    {
        InitializeComponent();
        BindingContext = registerPageViewModel;
    }
}