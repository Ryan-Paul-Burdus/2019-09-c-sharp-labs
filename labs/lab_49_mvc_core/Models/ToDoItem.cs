namespace lab_49_MVC_core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ToDoItem
    {
        public int ToDoItemId { get; set; }

        [StringLength(50)]
        public string Item { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? DateDue { get; set; }

        public bool? Done { get; set; }

        public int? UserId { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
