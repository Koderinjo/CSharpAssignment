using Business.Interfaces;
using Business.Models;
using Presentation.MAUI.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.MAUI.ViewModels
{
    public class ContactsListViewModel : BindableObject
    {
        private readonly IContactService _contactService;

        public ObservableCollection<Business.Models.Contact> Contacts { get; set; } = new ObservableCollection<Business.Models.Contact>();

        public ICommand EditContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactsListViewModel(IContactService contactService)
        {
            _contactService = contactService;
            LoadContacts();

            EditContactCommand = new Command(async (param) => await EditContact(param));
            DeleteContactCommand = new Command(DeleteContact);
        }

        private async Task EditContact(object? param)
        {
            if (param is Business.Models.Contact contact)
            {
                await GoToContactDetailsPage(contact);
            }
        }

        private async Task GoToContactDetailsPage(Business.Models.Contact? contact = null)
        {
            var viewModel = new ContactDetailsViewModel(_contactService);
            if (contact != null)
            {
                viewModel.SelectedContact = contact;
            }

            var detailsPage = new ContactDetailsPage(viewModel);
            await Shell.Current.Navigation.PushAsync(detailsPage);
        }

        private void DeleteContact(object? param)
        {
            if (param is Business.Models.Contact contact)
            {
                _contactService.DeleteContact(contact.Id);
                LoadContacts();
            }
        }

        public void LoadContacts()
        {
            Contacts.Clear();
            foreach (var contact in _contactService.GetAllContacts())
            {
                Contacts.Add(contact);
            }
        }
    }
}