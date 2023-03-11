using Blazored.Modal;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Portfolio_MauiNewsfeed.Filtering;
using Portfolio_MauiNewsfeed.Services;

namespace Portfolio_MauiNewsfeed;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();        
        builder.Services.AddBlazoredModal();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddTransient<NewsfeedService>();
        builder.Services.AddSingleton<WindowService>();
        builder.Services.AddSingleton<NewsfeedFilter>();
        builder.Services.AddTransient<IAppDataService<NewsfeedFilter>, NewsfeedFilterService>();

        return builder.Build();
    }
}
