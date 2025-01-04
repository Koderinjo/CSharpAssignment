using Business.Models;
using Business.Services;
using Xunit;
using System.IO;
using System.Linq;

namespace Business.Tests
{
    public class ContactServiceTests
    {
        private const string TestFilePath = "test_contacts.json";

        public ContactServiceTests()
        {
            File.WriteAllText(TestFilePath, "");
        }

        [Fact]
        public void AddContact_ShouldAddContactToList()
        {
            // Arrange
            var contactService = new ContactService(TestFilePath);
            var contact = new Contact
            {
                FirstName = "Test",
                LastName = "Testsson",
                Email = "test@testsson.com",
                PhoneNumber = "1234567890",
                StreetAddress = "Testgatan 1",
                PostalCode = "123 45",
                City = "Teststan"
            };

            // Act
            contactService.AddContact(contact);

            // Assert
            var contacts = contactService.GetAllContacts();
            Assert.Contains(contact, contacts);
        }

        [Fact]
        public void GetAllContacts_ShouldReturnAllContacts()
        {
            // Arrange
            var contactService = new ContactService(TestFilePath);
            var contact1 = new Contact { FirstName = "Test1", LastName = "Testsson", Email = "test1@testsson.com", PhoneNumber = "1234567890", StreetAddress = "Testgatan 1", PostalCode = "123 45", City = "Teststan" };
            var contact2 = new Contact { FirstName = "Test2", LastName = "Testsson", Email = "test2@testsson.com", PhoneNumber = "1234567890", StreetAddress = "Testgatan 2", PostalCode = "678 90", City = "Teststad" };
            contactService.AddContact(contact1);
            contactService.AddContact(contact2);

            // Act
            var contacts = contactService.GetAllContacts();

            // Assert
            Assert.Equal(2, contacts.Count);
            Assert.Contains(contact1, contacts);
            Assert.Contains(contact2, contacts);
        }

        [Fact]
        public void SaveContactsToFile_ShouldSaveContactsToJsonFile()
        {
            // Arrange
            var contactService = new ContactService(TestFilePath);
            var contact = new Contact { FirstName = "Test", LastName = "Testsson", Email = "test@testsson.com", PhoneNumber = "1234567890", StreetAddress = "Testgatan 1", PostalCode = "123 45", City = "Teststan" };
            contactService.AddContact(contact);

            // Act
            contactService.SaveContactsToFile(TestFilePath);

            // Assert
            Assert.True(File.Exists(TestFilePath));
            var savedContacts = contactService.GetAllContacts();
            Assert.Single(savedContacts);
            Assert.Equal(contact.FirstName, savedContacts[0].FirstName);
        }

        [Fact]
        public void LoadContactsFromFile_ShouldLoadContactsFromJsonFile()
        {
            // Arrange
            var contactService = new ContactService(TestFilePath);
            var contact = new Contact { FirstName = "Test", LastName = "Testsson", Email = "test@testsson.com", PhoneNumber = "1234567890", StreetAddress = "Testgatan 1", PostalCode = "123 45", City = "Teststan" };
            contactService.AddContact(contact);
            contactService.SaveContactsToFile(TestFilePath);

            var newContactService = new ContactService(TestFilePath);

            // Act
            var loadedContacts = newContactService.GetAllContacts();

            // Assert
            Assert.Single(loadedContacts);
            Assert.Equal(contact.FirstName, loadedContacts[0].FirstName);
        }

        [Fact]
        public void LoadContactsFromFile_ShouldHandleEmptyFile()
        {
            // Arrange
            var contactService = new ContactService(TestFilePath);

            // Act
            var contacts = contactService.GetAllContacts();

            // Assert
            Assert.Empty(contacts);
        }

        [Fact]
        public void LoadContactsFromFile_ShouldHandleInvalidJson()
        {
            // Arrange
            File.WriteAllText(TestFilePath, "Invalid JSON");
            var contactService = new ContactService(TestFilePath);

            // Act
            var contacts = contactService.GetAllContacts();

            // Assert
            Assert.Empty(contacts);
        }

    }
}