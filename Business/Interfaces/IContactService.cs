using System.Collections.Generic;
using Business.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        void AddContact(Contact contact);
        void SaveContactsToFile(string filePath);
        void LoadContactsFromFile(string filePath);
    }
}