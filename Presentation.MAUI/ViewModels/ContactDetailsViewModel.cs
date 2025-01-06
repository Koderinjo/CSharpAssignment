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
        public event PropertyChangedEventHandler? PropertyChanged;

        private Business.Models.Contact? _selectedContact;
        public Business.Models.Contact? SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                Contact = _selectedContact ?? new Business.Models.Contact()
                {
                    FirstName = string.Empty,
                    LastName = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,
                    StreetAddress = string.Empty,
                    PostalCode = string.Empty,
                    City = string.Empty
                };
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
        public ContactDetailsViewModel(IContactService contactService)
        {
            _contactService = contactService;
            _contact = new Business.Models.Contact()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                StreetAddress = string.Empty,
                PostalCode = string.Empty,
                City = string.Empty
            };

            SaveContactCommand = new Command(async () => await SaveContact());
            CancelCommand = new Command(async () => await Cancel());
        }

        private async Task SaveContact()
        {
            if (Contact != null)
            {
                if (SelectedContact == null)
                {
                    _contactService.AddContact(Contact);
                }
                else
                {
                    _contactService.UpdateContact(Contact);
                }
            }

            await Shell.Current.GoToAsync("..");
        }

        // Got help from Gemini with the pragma part, couldnt get rid of the warning otherwise
        #pragma warning disable IDE0079
        #pragma warning disable CA1822
                private async Task Cancel()
                {
                    await Shell.Current.GoToAsync("..");
                }
        #pragma warning restore CA1822
        #pragma warning restore IDE0079


        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}