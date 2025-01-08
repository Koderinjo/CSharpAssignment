using Business.Interfaces;
using Business.Models;

namespace Business.Factories
{
    public class ContactFactory : IContactFactory
    {
        public Contact CreateContact()
        {
            return new Contact
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                StreetAddress = string.Empty,
                PostalCode = string.Empty,
                City = string.Empty
            };
        }
    }
}