using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketAPI.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Key]
        [Column("categoriaid")]
        public int ID { get; set; }
        public String Nome { get; set; }
    }
}