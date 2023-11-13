using TestContainerAPP.Services.AuthService;

namespace TestContainerAPP.Pages;

public partial class LoadingPage : ContentPage
{
    private readonly IAuthService authService;

    public LoadingPage(IAuthService authService)
    {
        InitializeComponent();
        this.authService = authService;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

        if (await authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync($"//{nameof(ContainerPage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}