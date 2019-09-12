using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_23_LINQ
{
    class Program
    {
        static List<Customer> customers;

        static void Main(string[] args)
        {
#if DEBUG
    Console.WriteLine("We are in debug mode");
#endif 
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();


                //can't print this 
                //LINQ produces output of type 'IQueryable' 
                //This is an abstract type so we cast this to a list 
                var allCustomers = (from customer in db.Customers select customer).ToList();

                Console.WriteLine("\n\n=== Trivial LINQ query ===\n");
                allCustomers.ForEach(c => { Console.WriteLine($"{c.CustomerID}"); } );
                PrintCustomers(allCustomers);


                Console.WriteLine("\n\n=== LINQ where city is london or berlin ===\n");
                var LINQwhere =
                    from customer in db.Customers
                    where customer.City == "London" || customer.City == "Berlin"
                    select customer;
                LINQwhere.ToList().ForEach(c => Console.WriteLine($"{c.CustomerID, - 10}" 
                    + $"{c.City}"));
                PrintCustomers(LINQwhere.ToList());


                Console.WriteLine("\n\n=== Order by customer name ===\n");
                var LINQOrderBy =
                    (from customer in db.Customers
                     where customer.City == "London"
                     orderby customer.ContactName descending
                     select customer).ToList();
                PrintCustomers(LINQOrderBy);

                Console.WriteLine("\n\n=== Lambda has OrderBy..ThenBy ===\n");
                var LINQOrderByThenBy =
                    db.Customers.Where(c => c.City == "London" || c.City == "Berlin" || c.City == "Madrid")
                    .OrderBy(c => c.City)
                    .ThenBy(c => c.ContactName)
                    .ToList();
                PrintCustomers(LINQOrderByThenBy);

                Console.WriteLine("\n\n=== Creating a Custom output object ===\n");
                var customObject =
                    from c in db.Customers
                    join order in db.Orders
                        on c.CustomerID equals order.CustomerID
                    select new
                    {
                        Name = c.CompanyName,
                        order.OrderID,//dont need to do orderID = order.orderID because they are the same name
                        order.OrderDate,
                        City = order.ShipCity
                    };

                //manual print 
                customObject.ToList().ForEach(item => Console.WriteLine($"{item.Name, -35} {item.OrderID, -8} " +
                    $"{item.OrderDate:dd/mm/yyyy} \t {item.City}"));

                //slick version
                Console.WriteLine("\n\n=== Joining orders to customers using Lambda ===\n");
                db.Orders.Where(o => o.Customer.City == "Berlin").ToList().ForEach(o =>
                {
                    Console.WriteLine($"{o.Customer.ContactName} {o.Customer.City} " +
                        $"{o.OrderID} {o.OrderDate:dd/mm/yyyy}");
                });

                Console.WriteLine("\n\n=== Joining 3 tables : order Details, Orders, Customers ===\n");
                db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList()
                    .ForEach(od =>
                    {
                        Console.WriteLine($"{od.Order.Customer.ContactName, - 20}" +
                            $"{od.Order.Customer.City, -15}" +
                            $"{od.OrderID, -15}" +
                            $"{od.ProductID, - 7}" +
                            $"{od.Order.OrderDate:dd/mm/yyyy}");
                    });


                Console.WriteLine("\n\n=== Joining 4 tables : order Details, Orders, Customers, Products ===\n");
                db.Order_Details.Where(od => od.Order.Customer.City == "Berlin").ToList()
                    .ForEach(od =>
                    {
                        Console.WriteLine($"{od.Order.Customer.ContactName,-20}" +
                            $"{od.Order.Customer.City,-15}" +
                            $"{od.OrderID,-15}" +
                            $"{od.ProductID,-7}" +
                            $"{od.Product.ProductName, - 35}" +
                            $"{od.Order.OrderDate:dd/mm/yyyy}");
                    });
            }

            
        }

        //print customers
#region PrintBlock
        static void PrintCustomers(List<Customer> customers)
        {
            var maxCustomerIDLength = customers.Max(c => c.CustomerID.Length) + 2;
            var maxCustomerNameLength = customers.Max(c => c.ContactName.Length) + 1;
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID.PadRight(maxCustomerIDLength)}" +
                $"{c.ContactName.PadRight(maxCustomerNameLength)} {c.City}"));
        }
#endregion PrintBlock
    }
}
