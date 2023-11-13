using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TestContainerAPP.Pages;
using TestContainerAPP.Services.AuthService;
using TestContainerAPP.Services.ContainerService;

namespace TestContainerAPP.Models.ViewModels.Startup
{
    public partial class ContainerPageViewModel : BaseViewModel
    {
        private readonly IContainerService containerService;
        private readonly IAuthService authService;

        [ObservableProperty]
        private ObservableCollection<Container> containers;

        [ObservableProperty]
        private string cntrNo;

        [ObservableProperty]
        private string status;

        [ObservableProperty]
        private string thumbnail;



        public ContainerPageViewModel(IContainerService containerService, IAuthService authService)
        {
            this.containerService = containerService;
            this.authService = authService;
            _ = GenListContainer();
        }

        [RelayCommand]
        async Task Logout()
        {
            AuthService authService = new AuthService();
            authService.LogoutAsync();
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        async Task GenListContainer()
        {
            var containerList = await containerService.GetContainers();

            Containers = new ObservableCollection<Container>(containerList as List<Container>);
        }


    }
}
