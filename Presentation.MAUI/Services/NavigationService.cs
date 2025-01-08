using Business.Interfaces;
using Business.Models;
using Presentation.MAUI.Views;
using System.Threading.Tasks;

namespace Presentation.MAUI.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GoToContactDetailsPage(Business.Models.Contact? contact = null)
        {
            if (contact == null)
            {
                await Shell.Current.GoToAsync(nameof(ContactDetailsPage));
            }
            else
            {
                var parameters = new Dictionary<string, object>
                {
                    { "SelectedContact", contact }
                };
                await Shell.Current.GoToAsync(nameof(ContactDetailsPage), parameters);
            }
        }

        public async Task GoBack()
        {
            await Shell.Current.GoToAsync("..");
        }

        public async Task GoToContactsListPage()
        {
            await Shell.Current.GoToAsync(nameof(ContactsListPage));
        }
    }
}