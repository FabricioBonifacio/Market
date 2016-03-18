using MarketAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarketAPI.DAL
{
     public partial class ContextMarketAPI : DbContext
    {
         public ContextMarketAPI()
            : base("name=DefaultConnection")//ModelDeliveryAPI
        {
        }

         public virtual DbSet<Supermercado> Supermercado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Compra>()
            //    .HasMany(e => e.Itens)
            //    .WithRequired(e => e.Compra)
            //    .WillCascadeOnDelete(false);
        }

        public System.Data.Entity.DbSet<MarketAPI.Models.Unidade> Unidades { get; set; }

        public System.Data.Entity.DbSet<MarketAPI.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<MarketAPI.Models.FormaPagamento> FormaPagamentoes { get; set; }

        public System.Data.Entity.DbSet<MarketAPI.Models.Produto> Produtoes { get; set; }

        public System.Data.Entity.DbSet<MarketAPI.Models.Compra> Compras { get; set; }

        public System.Data.Entity.DbSet<MarketAPI.Models.Item> Items { get; set; }
    }
}