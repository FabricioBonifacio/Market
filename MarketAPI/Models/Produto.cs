using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketAPI.Models
{
    [Table("produto")]
    public class Produto
    {
        [Key]
        [Column("produtoid")]
        public int ID { get; set; }
        public String Nome { get; set; }
        public int CategoriaID { get; set; }
        public int UnidadeID { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Unidade Unidade { get; set; }
    }
}