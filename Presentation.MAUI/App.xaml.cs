using Presentation.MAUI.ViewModels;
using Presentation.MAUI.Views;

namespace Presentation.MAUI;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        _serviceProvider = serviceProvider;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var mainPage = new NavigationPage(new MainPage(_serviceProvider.GetRequiredService<MainPageViewModel>()));

        var window = new Window(mainPage);

        return window;
    }
}