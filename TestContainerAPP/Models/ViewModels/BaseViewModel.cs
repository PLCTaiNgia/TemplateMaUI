using CommunityToolkit.Mvvm.ComponentModel;

namespace TestContainerAPP.Models.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private bool _title;
    }
}
