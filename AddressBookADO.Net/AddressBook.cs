using System.Data.SqlClient;
using System.Data;
using System;

namespace AddressBookDatabase
{
    class AddressBook
    {
        //properties of addressBook
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public long phoneNumber { get; set; }
        public string email { get; set; }

        string outputMessage;
        string connectionString = @"Data Source=s;Initial Catalog=AddressBookADO;Integrated Security=True;Pooling=False";
        /// <summary>
        /// add new contact to addressbook database that contains contactBook table,
        /// returns true if insert successfull, else false.
        /// </summary>
        /// <param name="contact">refrence of addressBook model class</param>
        /// <returns></returns>
        public bool AddContact(AddressBook contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            int result = 0;
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpInsertNewContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@firstName", contact.firstName);
                    command.Parameters.AddWithValue("@lastName", contact.lastName);
                    command.Parameters.AddWithValue("@address", contact.address);
                    command.Parameters.AddWithValue("@city", contact.city);
                    command.Parameters.AddWithValue("@state", contact.state);
                    command.Parameters.AddWithValue("@zip", contact.zipcode);
                    command.Parameters.AddWithValue("@phoneNumber", contact.phoneNumber);
                    command.Parameters.AddWithValue("@email", contact.email);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    outputMessage = result == 1 ? "Contact Added SuccessFully" : "Contact Add failed";
                    Console.WriteLine(outputMessage);
                }
                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        /// <summary>
        /// retrieve contact from database returns contact details of a person
        /// </summary>
        /// <param name="name">name of the person</param>
        /// <returns></returns>
        public bool GetContact(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                int flag = 0;
                using (connection)
                {
                    string spName = "dbo.SpGetContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@firstName", name);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        flag++;
                        firstName = dr.GetString(0);
                        lastName = dr.GetString(1);
                        address = dr.GetString(2);
                        city = dr.GetString(3);
                        state = dr.GetString(4);
                        zipcode = dr.GetInt32(5);
                        phoneNumber = dr.GetInt64(6);
                        email = dr.GetString(7);
                        Console.WriteLine($"{firstName} {lastName} {address} {city} {state} {zipcode} {phoneNumber} {email}");
                    }
                    outputMessage = flag >= 1 ? $"{flag} Contact(s) found" : "Contact not found";
                    Console.WriteLine(outputMessage);
                    return flag >= 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        /// <summary>
        /// edit contact of particular person
        /// </summary>
        /// <param name="name">name of person</param>
        /// <param name="contact">contact details to be edited</param>
        /// <returns></returns>
        public bool EditContact(string name, AddressBook contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                int result;
                using (connection)
                {
                    string spName = "dbo.SpEditContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@firstName", contact.firstName);
                    command.Parameters.AddWithValue("@lastName", contact.lastName);
                    command.Parameters.AddWithValue("@address", contact.address);
                    command.Parameters.AddWithValue("@city", contact.city);
                    command.Parameters.AddWithValue("@state", contact.state);
                    command.Parameters.AddWithValue("@zip", contact.zipcode);
                    command.Parameters.AddWithValue("@phoneNumber", contact.phoneNumber);
                    command.Parameters.AddWithValue("@email", contact.email);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    outputMessage = result == 1 ? "Contact Edited SuccessFully" : "Contact Edit failed";
                    Console.WriteLine(outputMessage);
                }
                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        /// <summary>
        /// deletes particular contact of person
        /// </summary>
        /// <param name="name">name of the person to be deleted</param>
        /// <returns></returns>
        public bool DeleteContact(string name)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                int result;
                using (connection)
                {
                    string spName = "dbo.SpDeleteContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                    outputMessage = result >= 1 ? "Contact Deleted SuccessFully" : "Contact Delete Unsuccessfull";
                    Console.WriteLine(outputMessage);
                }
                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        /// <summary>
        /// Retrieve Contact by city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        public bool RetrieveContact(string city)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                int flag = 0;
                using (connection)
                {
                    string spName = "dbo.SpRetrieveContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.Parameters.AddWithValue("@city", city);
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        flag++;
                        firstName = dr.GetString(0);
                        lastName = dr.GetString(1);
                        address = dr.GetString(2);
                        city = dr.GetString(3);
                        state = dr.GetString(4);
                        zipcode = dr.GetInt32(5);
                        phoneNumber = dr.GetInt64(6);
                        email = dr.GetString(7);
                        Console.WriteLine($"{firstName} {lastName} {address} {city} {state} {zipcode} {phoneNumber} {email}");
                    }
                    outputMessage = flag >= 1 ? $"{flag} Contact(s) found" : "Contact not found";
                    Console.WriteLine(outputMessage);
                    return flag >= 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        /// <summary>
        /// get size of database by city and state
        /// </summary>
        /// <returns> true or false</returns>
        public bool GetSize()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string spName = "dbo.SpGetSize";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine($"Number of cities: {dr.GetInt32(0)} \n Number of states: {dr.GetInt32(1)}");
                    }
                    return dr != null ? true : false; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
