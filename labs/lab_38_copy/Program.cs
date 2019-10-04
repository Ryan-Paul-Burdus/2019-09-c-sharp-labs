using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace lab_38_copy
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static string connectionstring = @"Data Source =localhost;Initial Catalog=Northwind;Persist Security Info=True;User ID=SA;Password=Passw0rd2018";
        static string connectionstring2 = @"Data Source=(localdb)\mysqllocaldb;Initial Catalog=Northwind;";

        static void Main(string[] args)
        {
            GetCustomers();
        }

        static void GetCustomers()
        {


            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                Console.WriteLine(connection.State);
            }


            using (var connection2 = new SqlConnection(connectionstring2))
            {
                connection2.Open();
                Console.WriteLine(connection2.State);

                string sqlquery01 = "select * from customers";
                using (var sqlcommand = new SqlCommand(sqlquery01, connection2))
                {
                    var reader = sqlcommand.ExecuteReader();
                    while (reader.Read())
                    {
                        var CustomerID = reader["CustomerID"].ToString();
                        var ContactName = reader["ContactName"].ToString();
                        var CompanyName = reader["CompanyName"].ToString();
                        var City = reader["City"].ToString();
                        var Country = reader["Country"].ToString();
                        //new customer
                        var customer = new Customer(CustomerID, ContactName, CompanyName, City, Country);
                        //add customer to list of customers
                        customers.Add(customer);
                    }
                }

                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}, {c.ContactName,-20}, {c.CompanyName,-20}, {c.City}"));
            }
        }

        static void InsertCustomer()
        {
            using (var connection = new SqlConnection(connectionstring2))
            {
                connection.Open();
                var FixedCustomer = new Customer("Ryan1", "Ryan", "Sparta", "London", "UK");
                var sqlString = "INSERT INTO CUSTOMERS (CustomerID, ContactName, CompanyName, City, Country) " + $"VALUES('{FixedCustomer.CustomerID}'," +
                    $"'{FixedCustomer.ContactName}', '{FixedCustomer.CompanyName}', '{FixedCustomer.City}', '{FixedCustomer.Country}'";
                using (var command = new SqlCommand(sqlString, connection))
                {
                    int affected = command.ExecuteNonQuery();
                    Console.WriteLine($"{affected} rows inserted");
                }
            }
        }

        //static string GenerateRandomID()
        //{
        //    //generate random character generator with 5 fixed 
        //}
    }

    class Customer
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

        public Customer(string CustomerID, string ContactName, string CompanyName, string City, string Country)
        {
            this.CustomerID = CustomerID;
            this.ContactName = ContactName;
            this.CompanyName = CompanyName;
            this.City = City;
            this.Country = Country;
        }
    }
}
