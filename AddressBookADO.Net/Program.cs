using System;

namespace AddressBookDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Perform Address Book Problem Statement in ADO.Net");
            //initiliazing values of addressbook model
            AddressBook contact = new AddressBook
            {
                firstName = "John",
                lastName = "Doe",
                address = "some address",
                city = "xcity",
                state = "xstate",
                zipcode = 000000,
                phoneNumber = 999999999999,
                email = "emailme@email.com"
            };
            string res = contact.AddContact(contact) ? "Contact add successfull" : "Contact Add failed";
            Console.WriteLine(res);
        }
    }
}
