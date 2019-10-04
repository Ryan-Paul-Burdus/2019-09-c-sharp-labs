using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab_34_API_Northwind.Controllers
{
    public class CustomerNamesController : ApiController
    {
        public static List<string> customerList = new List<string>();
        public List<string> GetCustomerNames()
        {
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.ToList();
                foreach(var c in customers)
                {
                    customerList.Add(c.ContactName);
                }
            }
            return customerList;
        }
    }
}
