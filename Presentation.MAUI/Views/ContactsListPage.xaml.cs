using Presentation.MAUI.ViewModels;
using Business.Models;

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

        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var contact = e.SelectedItem as Business.Models.Contact;
                _viewModel.EditContactCommand.Execute(contact);
            }
        }
    }
}