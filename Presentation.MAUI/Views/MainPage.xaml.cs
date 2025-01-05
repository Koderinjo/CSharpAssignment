using Presentation.MAUI.ViewModels;

namespace Presentation.MAUI.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Add navigation logic here later
        }
    }
}