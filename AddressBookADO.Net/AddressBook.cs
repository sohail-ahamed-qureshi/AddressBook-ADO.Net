using System.Data.SqlClient;
using System.Data;
using System;

namespace AddressBookDatabase
{
    class AddressBook
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }

    }
}
