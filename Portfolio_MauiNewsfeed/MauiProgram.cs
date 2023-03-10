﻿using Blazored.Modal;
using Microsoft.Extensions.Logging;
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

        builder.Services.AddSingleton<NewsfeedFilter>();
        builder.Services.AddTransient<NewsfeedFilterService>();

        return builder.Build();
    }
}
