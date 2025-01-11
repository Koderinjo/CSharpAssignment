using System;
using System.Collections.Generic;
using Business.Interfaces;
using Business.Models;
using Moq;
using Xunit;

namespace Business.Tests
{
    public class ContactServiceTests
    {
        private readonly Mock<IContactService> _mockContactService;

        public ContactServiceTests()
        {
            _mockContactService = new Mock<IContactService>();
        }

        [Fact]
        public void GetAllContacts_ReturnsAllContacts()
        {
            // Arrange
            var expectedContacts = new List<Contact>
            {
                new Contact { Id = Guid.NewGuid(), FirstName = "Alice", LastName = "Doe", Email = "alice@example.com", PhoneNumber = "1234567890", StreetAddress = "Some Street 1", PostalCode = "123 45", City = "Some City" },
                new Contact { Id = Guid.NewGuid(), FirstName = "Bob", LastName = "Smith", Email = "bob@example.com", PhoneNumber = "0987654321", StreetAddress = "Some Street 2", PostalCode = "678 90", City = "Another City" }
            };

            _mockContactService.Setup(cs => cs.GetAllContacts()).Returns(expectedContacts);

            // Act
            var actualContacts = _mockContactService.Object.GetAllContacts();

            // Assert
            Assert.Equal(expectedContacts.Count, actualContacts.Count);
            Assert.Equal(expectedContacts, actualContacts);
        }

        [Fact]
        public void AddContact_AddsContactSuccessfully()
        {
            // Arrange
            var newContact = new Contact { Id = Guid.NewGuid(), FirstName = "Charlie", LastName = "Johnson", Email = "charlie@example.com", PhoneNumber = "1112223333", StreetAddress = "Test Street", PostalCode = "444 55", City = "Test City" };
            _mockContactService.Setup(cs => cs.AddContact(It.IsAny<Contact>()));

            // Act
            _mockContactService.Object.AddContact(newContact);

            // Assert
            _mockContactService.Verify(cs => cs.AddContact(newContact), Times.Once);
        }
    }
}
