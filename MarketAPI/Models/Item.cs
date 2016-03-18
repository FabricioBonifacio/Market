using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketAPI.Models
{
    [Table("item")]
    public class Item
    {
        [Key]
        [Column("itemid")]
        public int ID { get; set; }
        public int ProdutoID { get; set; }
        public int CompraID { get; set; }
        public int Numero { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal ValorUnitario { get; set; }
        public Decimal ValorTotal { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Compra Compra { get; set; }
    }
}