using Business.Interfaces;
using Business.Models;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Business.Tests
{
    public class NavigationServiceTests
    {
        [Fact]
        public async Task GoToContactDetailsPage_ShouldBeCalledWithCorrectContact()
        {
            // Arrange
            var mockNavigationService = new Mock<INavigationService>();
            var contact = new Contact
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "1234567890",
                StreetAddress = "Test Street",
                PostalCode = "123 45",
                City = "Test City"
            };

            // Act
            await mockNavigationService.Object.GoToContactDetailsPage(contact);

            // Assert
            mockNavigationService.Verify(ns => ns.GoToContactDetailsPage(contact), Times.Once);
        }

        [Fact]
        public async Task GoBack_ShouldBeCalledOnce()
        {
            // Arrange
            var mockNavigationService = new Mock<INavigationService>();

            // Act
            await mockNavigationService.Object.GoBack();

            // Assert
            mockNavigationService.Verify(ns => ns.GoBack(), Times.Once);
        }

        [Fact]
        public async Task GoToContactsListPage_ShouldBeCalledOnce()
        {
            // Arrange
            var mockNavigationService = new Mock<INavigationService>();

            // Act
            await mockNavigationService.Object.GoToContactsListPage();

            // Assert
            mockNavigationService.Verify(ns => ns.GoToContactsListPage(), Times.Once);
        }
    }
}
