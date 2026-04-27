using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ExamProject.DAL.Models
{
    [Table("table_products")]
    public record Product
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; } = 0;
        [Column("category_id")]
        public int CategoryId { get; set; }
        [Column("supplier_id")]
        public int SupplierId { get; set; }
    }
}
