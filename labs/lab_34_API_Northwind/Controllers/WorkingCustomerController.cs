using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace lab_34_API_Northwind.Controllers
{
    public class WorkingCustomerController : ApiController
    {

        public List<Customer> GetWorkingCustomer()
        {
            using (var db = new NorthwindEntities())
            {
                return db.Customers.ToList();
            }
            
        }
    }
}
