using System;
using System.Collections.Generic;
using System.IO;
using Business.Models;
using Business.Services;
using Xunit;

namespace Business.Tests
{
    public class ContactServiceIntegrationTests
    {
        private const string TestFilePath = "test_contacts.json";

        public ContactServiceIntegrationTests()
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
        public void LoadContactsFromFile_ShouldHandleEmptyFile()
        {
            // Arrange
            var contactService = new ContactService(TestFilePath);

            // Act
            var contacts = contactService.GetAllContacts();

            // Assert
            Assert.Empty(contacts);
        }
    }
}
