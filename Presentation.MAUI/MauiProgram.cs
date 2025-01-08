using Business.Factories;
using Business.Interfaces;
using Business.Services;
using Microsoft.Extensions.Logging;
using Presentation.MAUI.Services;
using Presentation.MAUI.ViewModels;
using Presentation.MAUI.Views;

namespace Presentation.MAUI;

public static class MauiProgram
{
    public static string FilePath { get; private set; }

    static MauiProgram()
    {
        FilePath = Path.Combine(FileSystem.AppDataDirectory, "contacts.json");
    }

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IContactService>(new ContactService(FilePath));
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddSingleton<AppShell>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ContactDetailsPage>();

        builder.Services.AddTransient<ContactsListPage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddTransient<ContactDetailsViewModel>();
        builder.Services.AddTransient<ContactsListViewModel>();

        builder.Services.AddTransient<IContactFactory, ContactFactory>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}