using Business.Interfaces;
using Business.Models;
using System;
using System.Collections.Generic;

namespace Presentation.Console.MainApp
{
    public class ConsoleUI(IContactService contactService)
    {
        private readonly IContactService _contactService = contactService;

        public void Run()
        {
            while (true)
            {
                ShowMenu();
                var choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListContacts();
                        break;
                    case "2":
                        AddContact();
                        break;
                    case "0":
                        return;
                    default:
                        System.Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            System.Console.WriteLine("\nKontaktlista");
            System.Console.WriteLine("1. Lista kontakter");
            System.Console.WriteLine("2. Lägg till kontakt");
            System.Console.WriteLine("0. Avsluta");
            System.Console.Write("Välj ett alternativ: ");
        }

        private void ListContacts()
        {
            var contacts = _contactService.GetAllContacts();

            if (contacts.Count == 0)
            {
                System.Console.WriteLine("Inga kontakter i listan.");
                return;
            }

            foreach (var contact in contacts)
            {
                System.Console.WriteLine($"\nID: {contact.Id}");
                System.Console.WriteLine($"Namn: {contact.FirstName} {contact.LastName}");
                System.Console.WriteLine($"Email: {contact.Email}");
                System.Console.WriteLine($"Telefon: {contact.PhoneNumber}");
                System.Console.WriteLine($"Adress: {contact.StreetAddress}, {contact.PostalCode} {contact.City}");
            }
        }

        private void AddContact()
        {
            System.Console.WriteLine("\nLägg till ny kontakt");

            System.Console.Write("Förnamn: ");
            var firstName = System.Console.ReadLine() ?? string.Empty;

            System.Console.Write("Efternamn: ");
            var lastName = System.Console.ReadLine() ?? string.Empty;

            System.Console.Write("Email: ");
            var email = System.Console.ReadLine() ?? string.Empty;

            System.Console.Write("Telefonnummer: ");
            var phoneNumber = System.Console.ReadLine() ?? string.Empty;

            System.Console.Write("Gatuadress: ");
            var streetAddress = System.Console.ReadLine() ?? string.Empty;

            System.Console.Write("Postnummer: ");
            var postalCode = System.Console.ReadLine() ?? string.Empty;

            System.Console.Write("Ort: ");
            var city = System.Console.ReadLine() ?? string.Empty;

            var contact = new Contact
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                StreetAddress = streetAddress,
                PostalCode = postalCode,
                City = city
            };

            _contactService.AddContact(contact);

            System.Console.WriteLine("Kontakt tillagd!");
        }
    }
}