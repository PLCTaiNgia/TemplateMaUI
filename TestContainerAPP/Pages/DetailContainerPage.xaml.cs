using TestContainerAPP.Models.ViewModels.Startup;

namespace TestContainerAPP.Pages;


public partial class DetailContainerPage : ContentPage
{
    public DetailContainerPage(DetailContainerPageViewModel detailContainerPageViewModel)
    {
        InitializeComponent();

        this.BindingContext = detailContainerPageViewModel;
    }
}