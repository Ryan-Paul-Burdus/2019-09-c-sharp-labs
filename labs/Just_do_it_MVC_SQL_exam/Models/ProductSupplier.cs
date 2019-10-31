using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Just_do_it_MVC_SQL_exam.Models
{
    public class ProductSupplier
    {
        public Product product { get; set; }
        public Supplier supplier { get; set; }
    }
}
