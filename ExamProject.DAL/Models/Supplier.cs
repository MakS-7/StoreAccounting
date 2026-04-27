using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamProject.DAL.Models
{
    [Table("table_suppliers")]
    public record Supplier
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [ForeignKey("supplier_id")]
        [InverseProperty("table_suppliers")]
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}
