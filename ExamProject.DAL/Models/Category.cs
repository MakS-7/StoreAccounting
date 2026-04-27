using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamProject.DAL.Models
{
    [Table("table_categories")]
    public record Category
    {
        [Key]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [ForeignKey("category_id")]
        [InverseProperty("table_categories")]
        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
