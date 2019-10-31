namespace lab_49_MVC_core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Category
    {
        public Category()
        {
            ToDoItems = new HashSet<ToDoItem>();
        }

        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
