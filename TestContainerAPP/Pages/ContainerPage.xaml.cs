using TestContainerAPP.Models;
using TestContainerAPP.Models.ViewModels.Startup;
using TestContainerAPP.Services.ContainerService;

namespace TestContainerAPP.Pages;

public partial class ContainerPage : ContentPage
{
    private readonly IContainerService containerService;

    public ContainerPage(ContainerPageViewModel containerPageViewModel)
    {
        InitializeComponent();

        this.BindingContext = containerPageViewModel;
    }

    private async void AddData()
    {
        var containers = await containerService.GetContainers();

        LsvContainers.ItemsSource = containers;
    }

    private async void LsvContainers_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var container = LsvContainers.SelectedItem as Container;

        await Shell.Current.GoToAsync($"//{nameof(DetailContainerPage)}", true, new Dictionary<string, object>
        {
            {"Container", container }
        });
    }
}