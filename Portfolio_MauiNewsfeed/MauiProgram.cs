using Blazored.Modal;
using Microsoft.Extensions.Logging;
using Portfolio_MauiNewsfeed.Filtering;
using Portfolio_MauiNewsfeed.Services;
using Microsoft.EntityFrameworkCore;
using Portfolio_MauiNewsfeed.Data;

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
        builder.Services.AddDbContextFactory<NewsfeedDbContext>(options => options.UseSqlite("Data Source=NewsfeedDb.sqlite3"));

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Services.AddBlazoredModal();
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<NewsfeedFilter>();
        builder.Services.AddTransient<NewsfeedFilterService>();

        return builder.Build();
    }
}
