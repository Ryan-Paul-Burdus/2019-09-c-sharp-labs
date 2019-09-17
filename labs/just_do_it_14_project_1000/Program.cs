using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace just_do_it_14_project_1000
{
    class Program
    {
        static List<Customer> customers;

        static void Main(string[] args)
        {
            using (var db = new ShopDbEntities1())
            {
                customers = db.Customers.ToList();
            }

            var newCustomer = new Customer()
            {
                FirstName = $"Customer{customers.Count + 1}",
                LastName = "LastName"
            };

            File.WriteAllText("CustomerOutput.csv", "ID, FirstName, LastName");
            File.AppendAllText("CustomerOutput.csv", "\n 1, BIlly, Smith");
        }
        
    }
}
