using CommunityToolkit.Maui;
using DevExpress.Maui;
using TestContainerAPP.Models.ViewModels.Startup;
using TestContainerAPP.Pages;
using TestContainerAPP.Services.AuthService;
using TestContainerAPP.Services.ContainerService;

namespace TestContainerAPP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseDevExpress(useLocalization: true)
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("univia-pro-regular.ttf", "Univia-Pro");
                    fonts.AddFont("roboto-bold.ttf", "Roboto-Bold");
                    fonts.AddFont("roboto-regular.ttf", "Roboto");
                });

            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IContainerService, ContainerService>();

            builder.Services.AddTransient<LoadingPage>();
            builder.Services.AddTransient<ContainerPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddSingleton<ChangePasswordPage>();
            builder.Services.AddTransient<DetailContainerPage>();

            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<RegisterPageViewModel>();
            builder.Services.AddTransient<ChangePasswordPageViewModel>();
            builder.Services.AddTransient<ContainerPageViewModel>();
            builder.Services.AddTransient<DetailContainerPageViewModel>();

            var app = builder.Build();

            return app;
        }
    }
}