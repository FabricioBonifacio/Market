using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketAPI.Models
{
    [Table("unidade")]
    public class Unidade
    {
        [Key]
        [Column("unidadeid")]
        public int ID { get; set; }
        public String Nome { get; set; }
        public String Sigla { get; set; }
    }
}