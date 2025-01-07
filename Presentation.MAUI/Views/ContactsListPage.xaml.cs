using Presentation.MAUI.ViewModels;

namespace Presentation.MAUI.Views
{
    public partial class ContactsListPage : ContentPage
    {
        private ContactsListViewModel _viewModel;

        public ContactsListPage(ContactsListViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadContacts();
        }


    }
}