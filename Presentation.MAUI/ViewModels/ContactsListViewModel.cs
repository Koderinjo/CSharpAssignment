using Business.Interfaces;
using Business.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.MAUI.ViewModels
{
    public class ContactsListViewModel : BindableObject
    {
        private readonly IContactService _contactService;
        private readonly INavigationService _navigationService;

        public ObservableCollection<Business.Models.Contact> Contacts { get; set; } = new ObservableCollection<Business.Models.Contact>();

        public ICommand EditContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactsListViewModel(IContactService contactService, INavigationService navigationService)
        {
            _contactService = contactService;
            _navigationService = navigationService;
            LoadContacts();

            EditContactCommand = new Command(async (param) => await EditContact(param));
            DeleteContactCommand = new Command(async (param) => await DeleteContact(param));
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
            await _navigationService.GoToContactDetailsPage(contact);
        }

        private Task DeleteContact(object? param)
        {
            if (param is Business.Models.Contact contact)
            {
                _contactService.DeleteContact(contact.Id);
                LoadContacts();
            }
            return Task.CompletedTask;
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