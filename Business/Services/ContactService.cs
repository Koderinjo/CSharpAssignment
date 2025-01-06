using Business.Interfaces;
using Business.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Business.Services
{
    public class ContactService : IContactService
    {
        private List<Contact> _contacts;
        private readonly string _filePath;

        public ContactService(string filePath)
        {
            _contacts = [];
            _filePath = filePath;
            LoadContactsFromFile(_filePath);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
            SaveContactsToFile(_filePath);
        }

        public void SaveContactsToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(_contacts);
            File.WriteAllText(filePath, json);
        }

        public void LoadContactsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);

                try
                {
                    _contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? [];
                }
                catch (JsonException)
                {
                    _contacts = [];
                }
            }
            else
            {
                _contacts = [];
            }
        }

        public void DeleteContact(Guid contactId)
        {
            var contactToRemove = _contacts.FirstOrDefault(c => c.Id == contactId);
            if (contactToRemove != null)
            {
                _contacts.Remove(contactToRemove);
                SaveContactsToFile(_filePath);
            }
        }

        public void UpdateContact(Contact updatedContact)
        {
            var existingContact = _contacts.FirstOrDefault(c => c.Id == updatedContact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = updatedContact.FirstName;
                existingContact.LastName = updatedContact.LastName;
                existingContact.Email = updatedContact.Email;
                existingContact.PhoneNumber = updatedContact.PhoneNumber;
                existingContact.StreetAddress = updatedContact.StreetAddress;
                existingContact.PostalCode = updatedContact.PostalCode;
                existingContact.City = updatedContact.City;

                SaveContactsToFile(_filePath);
            }
        }
    }
}