using Business.Interfaces;
using Business.Models;
using Presentation.MAUI.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Presentation.MAUI.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IContactService _contactService;

        public ObservableCollection<Business.Models.Contact> Contacts { get; set; } = [];

        public ICommand AddContactCommand { get; private set; }
        public ICommand EditContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public MainPageViewModel(IContactService contactService)
        {
            _contactService = contactService;
            LoadContacts();

            // Updated AddContactCommand to use GoToContactDetailsPage without parameters
            AddContactCommand = new Command(async () => await GoToContactDetailsPage());
            EditContactCommand = new Command(async (param) => await EditContact(param));
            DeleteContactCommand = new Command(DeleteContact);
        }

        // Updated GoToContactDetailsPage to have a nullable parameter and to use parameterless navigation.
        private async Task GoToContactDetailsPage(Business.Models.Contact? contact = null)
        {
            if (contact == null)
            {
                await Shell.Current.GoToAsync(nameof(ContactDetailsPage));
            }
            else
            {
                // Navigation for editing an existing contact
                await Shell.Current.GoToAsync(nameof(ContactDetailsPage), new Dictionary<string, object>
                {
                    { "SelectedContact", contact }
                });
            }
        }


        private async Task EditContact(object? param)
        {
            if (param is Business.Models.Contact contact)
            {
                // Navigate to the detailspage and pass the contact
                await Shell.Current.GoToAsync(nameof(ContactDetailsPage), new Dictionary<string, object>
                {
                    { "SelectedContact", contact }
                });
            }
        }

        private void DeleteContact(object? param)
        {
            if (param is Business.Models.Contact contact)
            {
                _contactService.DeleteContact(contact.Id);
                LoadContacts(); // Refresh the list after deleting
            }
        }

        private void LoadContacts()
        {
            Contacts.Clear();
            foreach (var contact in _contactService.GetAllContacts())
            {
                Contacts.Add(contact);
            }
        }
    }
}