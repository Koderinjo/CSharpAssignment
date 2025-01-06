using Presentation.MAUI.ViewModels;

namespace Presentation.MAUI.Views
{
    public partial class ContactDetailsPage : ContentPage
    {
        public ContactDetailsPage(ContactDetailsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}