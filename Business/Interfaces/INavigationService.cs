using Business.Models;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface INavigationService
    {
        Task GoToContactDetailsPage(Contact? contact = null);
        Task GoBack();
        Task GoToContactsListPage();
    }
}