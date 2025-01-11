using Business.Factories;
using Business.Models;
using Xunit;

namespace Business.Tests
{
    public class ContactFactoryTests
    {
        [Fact]
        public void ContactFactory_CreatesEmptyContactSuccessfully()
        {
            // Arrange
            var factory = new ContactFactory();

            // Act
            var contact = factory.CreateContact();

            // Assert
            Assert.NotNull(contact);
            Assert.Equal(string.Empty, contact.FirstName);
            Assert.Equal(string.Empty, contact.LastName);
            Assert.Equal(string.Empty, contact.Email);
            Assert.Equal(string.Empty, contact.PhoneNumber);
            Assert.Equal(string.Empty, contact.StreetAddress);
            Assert.Equal(string.Empty, contact.PostalCode);
            Assert.Equal(string.Empty, contact.City);
        }
    }
}
