namespace lab_41_entity_code_first_from_db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orange
    {
        
        public Orange()
        {
            Batches = new HashSet<Batch>();
        }

        [Key]
        public int OrangeID { get; set; }

        [StringLength(50)]
        public string OrangeName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateHarvested { get; set; }

        public bool? IsLuxuryGrade { get; set; }

        public int? OrangeCategoryID { get; set; }

        public int MaxOrangesPerCrate { get; set; }

        
        public virtual ICollection<Batch> Batches { get; set; }

        public virtual Category Category { get; set; }
    }
}
