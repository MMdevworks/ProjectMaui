using Microsoft.Extensions.Logging;
using ProjectMaui.Services;
using ProjectMaui.ViewModels;
using ProjectMaui.Views;
using CommunityToolkit.Maui;

namespace ProjectMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                //integrates the CommunityToolkit for MAUI into your app, enabling functionalities like animations, behaviors, etc.
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
    		builder.Logging.AddDebug();
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<LocalDbService>();
            builder.Services.AddSingleton<ExerciseService>();
            builder.Services.AddSingleton<ExerciseViewModel>();
            builder.Services.AddTransient<ExerciseDetailsView>();
            builder.Services.AddTransient<ExerciseDetailsPage>();
#endif

            return builder.Build();
        }
    }
}
