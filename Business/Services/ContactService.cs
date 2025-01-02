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
                var contacts = JsonSerializer.Deserialize<List<Contact>>(json);
                _contacts = contacts ?? new List<Contact>();
            }
        }
    }
}