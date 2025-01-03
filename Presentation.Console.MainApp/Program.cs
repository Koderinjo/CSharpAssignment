using Business.Interfaces;
using Business.Services;
using Presentation.Console.MainApp;
using System;

namespace Presentation.Console.MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"../../../../Business/JsonFiles/contacts.json";
            IContactService contactService = new ContactService(filePath);
            var ui = new ConsoleUI(contactService);
            ui.Run();
        }
    }
}