using System;

namespace Business.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string StreetAddress { get; set; }
        public required string PostalCode { get; set; }
        public required string City { get; set; }

        public Contact()
        {
            Id = Guid.NewGuid();
        }
    }
}