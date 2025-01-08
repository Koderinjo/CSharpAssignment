using Business.Interfaces;
using System.Windows.Input;

namespace Presentation.MAUI.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        private readonly INavigationService _navigationService;

        public ICommand ShowContactsCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowContactsCommand = new Command(async () => await ShowContacts());
            AddContactCommand = new Command(async () => await GoToContactDetailsPage());
        }

        private async Task ShowContacts()
        {
            await _navigationService.GoToContactsListPage();
        }

        private async Task GoToContactDetailsPage()
        {
            await _navigationService.GoToContactDetailsPage();
        }
    }
}