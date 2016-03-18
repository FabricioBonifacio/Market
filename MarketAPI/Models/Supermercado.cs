using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketAPI.Models
{
    [Table("supermercado")]
    public class Supermercado
    {
        [Key]
        [Column("supermercadoid")]
        public int ID { get; set; }
        public String Nome { get; set; }
    }
}