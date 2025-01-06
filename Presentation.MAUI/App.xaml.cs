#pragma warning disable CS0618
namespace Presentation.MAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
#pragma warning restore CS0618