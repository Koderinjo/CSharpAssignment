using Business.Models;
using Business.Services;
using Xunit;

namespace Business.Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public void AddContact_ShouldAddContactToList()
        {
            string filePath = "test_contacts.json";
            var contactService = new ContactService(filePath);
            var contact = new Contact
            {
                FirstName = "Test",
                LastName = "Testsson",
                Email = "test@testsson.com",
                PhoneNumber = "123-456-7890",
                StreetAddress = "123 Test St",
                PostalCode = "12345",
                City = "Testville"
            };

            contactService.AddContact(contact);

            var contacts = contactService.GetAllContacts();
            Assert.Contains(contact, contacts);
        }
    }
}