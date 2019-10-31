namespace lab_49_MVC_users_categories_todoitems
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
            ToDoItems = new HashSet<ToDoItem>();
        }

        public int CategoryId { get; set; }

        [StringLength(50)]
        public string CtegoryName { get; set; }

        public virtual ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
