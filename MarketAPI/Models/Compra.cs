using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarketAPI.Models
{
    [Table("compra")]
    public class Compra
    {
        [Key]
        [Column("compraid")]
        public int ID { get; set; }
        public int SupermercadoID { get; set; }
        public int FormaPagamentoID { get; set; }
        public DateTime Data { get; set; }
        public Decimal Valor { get; set; }
        [NotMapped]
        public String DataTexto { get; set; }
        [NotMapped]
        public List<Item> Itens { get; set; }
        

        public virtual Supermercado Supermercado { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }
        //public virtual List<Item> Itens { get; set; }
    }
}