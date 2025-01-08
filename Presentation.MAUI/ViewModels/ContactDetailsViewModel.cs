using Business.Interfaces;
using Business.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Presentation.MAUI.ViewModels
{
    [QueryProperty(nameof(SelectedContact), "SelectedContact")]
    public partial class ContactDetailsViewModel : INotifyPropertyChanged
    {
        private readonly IContactService _contactService;
        private readonly INavigationService _navigationService;
        private readonly IContactFactory _contactFactory;

        public event PropertyChangedEventHandler? PropertyChanged;

        private Business.Models.Contact? _selectedContact;
        public Business.Models.Contact? SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                Contact = _selectedContact ?? _contactFactory.CreateContact();
                OnPropertyChanged(nameof(Contact));
            }
        }

        private Business.Models.Contact _contact;
        public Business.Models.Contact Contact
        {
            get => _contact;
            set
            {
                if (_contact != value)
                {
                    _contact = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveContactCommand { get; private set; }
        public ICommand CancelCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ContactDetailsViewModel(IContactService contactService, INavigationService navigationService, IContactFactory contactFactory)
        {
            _contactService = contactService;
            _navigationService = navigationService;
            _contactFactory = contactFactory;
            _contact = _contactFactory.CreateContact();

            SaveContactCommand = new Command(async () => await SaveContact());
            CancelCommand = new Command(async () => await Cancel());
            DeleteContactCommand = new Command(async () => await DeleteContact());
        }

        private async Task SaveContact()
        {
            if (SelectedContact == null)
            {
                _contactService.AddContact(Contact);
            }
            else
            {
                _contactService.UpdateContact(Contact);
            }
            await _navigationService.GoBack();
        }

        private async Task Cancel()
        {
            await _navigationService.GoBack();
        }

        private async Task DeleteContact()
        {
            if (SelectedContact != null)
            {
                _contactService.DeleteContact(SelectedContact.Id);
            }
            await _navigationService.GoBack();
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}