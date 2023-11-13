using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using TodoApp.ViewModels;
using TodoApp.Views;

namespace TodoApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            #region DI Views

            builder.Services.AddTransient<TodoPage>();
            builder.Services.AddTransient<TodoDetailPage>();

            #endregion

            #region DI ViewModels

            builder.Services.AddTransient<TodoPageViewModel>();
            builder.Services.AddTransient<TodoDetailPageViewModel>();

            #endregion

            return builder.Build();
        }
    }
}