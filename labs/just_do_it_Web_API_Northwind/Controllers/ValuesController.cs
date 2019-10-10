using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace just_do_it_Web_API_Northwind.Controllers
{
    public class ValuesController : ApiController
    {
        static List<Customer> customers;

        // GET api/values
        public IEnumerable<string> Get()
        {
            using (var db = new NorthwindEntities())
            {
                customers = db.Customers.ToList();
            }
            Console.WriteLine("All customers!");
            string customerString = "";
            foreach (Customer c in customers)
            {
               customerString += $"{c.ContactName}"; 
            }

            yield return customerString;
        }

        // GET api/values/5
        public string Get(string id)
        {
            return id;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
