using Microsoft.AspNetCore.Components.WebView.Maui;
using PE.Data;
using PE.Implements;
using PE.Services;

namespace PE;

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
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddSingleton<IRequest>(serviceProvider =>
        {
            return new RequestService("http://192.168.0.5:8080"); //colocar ip propia
        });




        return builder.Build();
	}
}

