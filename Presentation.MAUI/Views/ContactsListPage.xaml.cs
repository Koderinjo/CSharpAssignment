using Presentation.MAUI.ViewModels;

namespace Presentation.MAUI.Views
{
    public partial class ContactsListPage : ContentPage
    {
        public ContactsListPage(ContactsListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}