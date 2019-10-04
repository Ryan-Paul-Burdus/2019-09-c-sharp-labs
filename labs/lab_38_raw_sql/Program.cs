using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace lab_38_raw_sql
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();


        static string connectionstring = null;
        static string connectionstring2 = @"Data Source = (localdb)\mssqllocaldb;Initial Catalog=Northwind;";

        
        static void Main(string[] args)
        {
            Environment.SetEnvironmentVariable("SecretPassword", "Passw0rd2018");
            var secret = Environment.GetEnvironmentVariable("SecretPassword");
            connectionstring = $"Data Source = localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=SA;Password={secret}";

            //using (var connection = new SqlConnection(connectionstring))
            //{
            //    connection.Open();
            //    Console.WriteLine(connection.State);
            //}


            //GenerateRandomId();
            //for (int i = 0; i < 10; i++)
            //{
            //    InsertCustomer();
            //}
            UpdateCustomer();

            DeleteCustomer();

            GetCustomers();
        }

        static void GetCustomers()
        {
            using (var connection2 = new SqlConnection(connectionstring))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);


                //code
                string sqlquery01 = "select * from customers";
                using (var sqlcommand = new SqlCommand(sqlquery01, connection2))
                {
                    //read customers on a loop
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerId = reader["CustomerID"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var City = reader["City"].ToString();
                        var Country = reader["Country"].ToString();
                        var customer = new Customer(CustomerId, CompanyName, ContactName, City, Country);
                        customers.Add(customer);
                    }
                }
                Console.WriteLine("\nReading All Customers From Northwind\n\n");
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-25}{c.CompanyName,-30}{c.City}"));





                Console.WriteLine($"\nThere are {customers.Count} customers\n\n");
            }
        }

        static void InsertCustomer()
        {
            using (var connection = new SqlConnection(connectionstring2))
            {
                connection.Open();
                var randomCustomerId = GenerateRandomId();
                var FixedCustomer = new Customer(randomCustomerId, "Sparta", "Ryan", "London", "UK");
                var sqlstring = $"INSERT INTO CUSTOMERS (CustomerID,ContactName,CompanyName,City,Country) " +
                    $"VALUES ('{FixedCustomer.CustomerID}','{FixedCustomer.ContactName}','{FixedCustomer.CompanyName}','{FixedCustomer.City}','{FixedCustomer.Country}')";
                using (var command = new SqlCommand(sqlstring, connection))
                {
                    int affected = command.ExecuteNonQuery();
                    Console.WriteLine($"{affected} rows inserted");
                }



                //insert using parameters
                //use parameters when taking values from eg form on screen
                //generate new IDvar randomCustomerId = GenerateRandomId();
                randomCustomerId = GenerateRandomId();
                Console.WriteLine($"NEW ID IS {randomCustomerId}");
                FixedCustomer = new Customer(randomCustomerId, "Sparta", "Ryan", "London", "UK");
                var insertWithParameters = new SqlCommand("INSERT INTO CUSTOMERS (CustomerID,ContactName,CompanyName,City,Country)"
                    + "VALUES(@CustomerID, @ContactName, @CompanyName, @City, @Country)", connection);
                insertWithParameters.Parameters.AddWithValue("@CustomerID", randomCustomerId);
                insertWithParameters.Parameters.AddWithValue("@ContactName", "Phil");
                insertWithParameters.Parameters.AddWithValue("@CompanyName", "Sparta");
                insertWithParameters.Parameters.AddWithValue("@City", "London");
                insertWithParameters.Parameters.AddWithValue("@Country", "UK");
                var sqlreader = insertWithParameters.ExecuteReader();



            }
        }

        static void UpdateCustomer()
        {
            using (var connection = new SqlConnection(connectionstring2))
            {
                connection.Open();
                var customerIdToUpdate = "'ALFKI'";
                var sqlUpdate = $"UPDATE CUSTOMERS SET City='Paris' WHERE CustomerID={customerIdToUpdate}";
                using (var sqlcommand = new SqlCommand(sqlUpdate, connection))
                {
                    int affected = sqlcommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records updated : {affected}");
                }
            }
        }

        static void DeleteCustomer()
        {
            using (var connection = new SqlConnection(connectionstring2))
            {
                connection.Open();
                var customerIdToDelete = "'ZRXYQ'";
                var sqlDelete = $"DELETE FROM CUSTOMERS WHERE CustomerID={customerIdToDelete}";
                using (var sqlcommand = new SqlCommand(sqlDelete, connection))
                {
                    int affected = sqlcommand.ExecuteNonQuery();
                    Console.WriteLine($"Number of records deleted: {affected}");
                }
            }
        }

        static string GenerateRandomId()
        {

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZABCDEFGHIJKLMNOPQRSTUVXYZ";
            string ID = "";





            for (int i = 0; i < 5; i++)
            {
                Random r = new Random();
                ID += alphabet[r.Next(0, alphabet.Length)];
            }
            return ID;
        }
    }

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public Customer() { }
        public Customer(string customerId, string companyName, string contactName, string city, string country)
        {
            this.CustomerID = customerId;
            this.CompanyName = companyName;
            this.ContactName = contactName;
            this.City = city;
            this.Country = country;
        }
    }
}