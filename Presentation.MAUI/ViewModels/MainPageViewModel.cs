using Business.Interfaces;
using Presentation.MAUI.Views;
using System.Windows.Input;

namespace Presentation.MAUI.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IContactService _contactService;

        public ICommand ShowContactsCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }

        public MainPageViewModel(IContactService contactService)
        {
            _contactService = contactService;

            ShowContactsCommand = new Command(async () => await NavigateToContactsListPage());
            AddContactCommand = new Command(async () => await GoToContactDetailsPage());
        }

        private async Task NavigateToContactsListPage()
        {
            await Shell.Current.GoToAsync(nameof(ContactsListPage));
        }

        private async Task GoToContactDetailsPage()
        {
            await Shell.Current.GoToAsync(nameof(ContactDetailsPage));
        }

        internal void GoToContactDetailsPage(Business.Models.Contact? contact)
        {
            throw new NotImplementedException();
        }
    }
}