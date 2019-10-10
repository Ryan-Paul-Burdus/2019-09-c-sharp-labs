using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace lab_45_streaming
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static List<Customer> customerFromXML = new List<Customer>();
        static void Main(string[] args)
        {
            var customer1 = new Customer()
            {
                CustomerID = "BOB22",
                ContactName = "Bob",
                CompanyName = "Sparta",
                City = "Berlin"
            };
            var customer2 = new Customer()
            {
                CustomerID = "ALFKI",
                ContactName = "Fred",
                CompanyName = "Sparta",
                City = "Berlin"
            };
            var customer3 = new Customer()
            {
                CustomerID = "CHAR1",
                ContactName = "Charles",
                CompanyName = "Sparta",
                City = "Berlin"
            };
            customers.Add(customer1);
            customers.Add(customer2);
            customers.Add(customer3);

            //List 
            //serialize to xml, json and binary
            var formatter = new SoapFormatter();
            //save to file ('stream' to file system)
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, customers);
            }
            Console.WriteLine(File.ReadAllText("data.xml"));
            //reverse process -> stream back and deserialize data
            ;
            //deserialize to list
            using (var reader = File.OpenRead("data.xml"))
            {
                customerFromXML = formatter.Deserialize(reader) as List<Customer>;
            }
            customerFromXML.ForEach(c => { Console.WriteLine($"{c.CustomerID,-15}, {c.ContactName,-20}, {c.City}"); });
        }
    }

    [Serializable]
    class Customer
    {
        [NonSerialized]
        private string NINO;
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }
}
