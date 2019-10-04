namespace lab_41_entity_code_first_from_db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        
        public Category()
        {
            Oranges = new HashSet<Orange>();
        }

        public int CategoryID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        
        public virtual ICollection<Orange> Oranges { get; set; }
    }
}
