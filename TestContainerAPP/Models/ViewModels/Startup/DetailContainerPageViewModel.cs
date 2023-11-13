using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TestContainerAPP.Dto;
using TestContainerAPP.Pages;
using TestContainerAPP.Services.ContainerService;

namespace TestContainerAPP.Models.ViewModels.Startup
{
    [QueryProperty(nameof(Container), "Container")]
    public partial class DetailContainerPageViewModel : BaseViewModel
    {
        private readonly IContainerService containerService;
        [ObservableProperty]
        private Container container;

        public DetailContainerPageViewModel(IContainerService containerService)
        {
            this.containerService = containerService;
        }

        [RelayCommand]
        async Task GotoContainerPage()
        {
            await Shell.Current.GoToAsync($"//{nameof(ContainerPage)}");
        }

        [RelayCommand]
        async Task SaveUpdateContainer()
        {
            var container = new UpdateContainerRequestDto
            {
                CMStatus = Container.CMStatus,
                CntrSize = Container.CntrSize,
                OprId = Container.OprId,
                Status = Container.Status,
                Thumbnail = Container.Thumbnail
            };

            var isSuccess = await containerService.UpdateContainerAsync(Container.CntrNo, container);
            if (isSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Info", "Sửa đổi thông tin thành công", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Sửa đổi thông tin thất bại", "OK");
            }
        }
    }
}
