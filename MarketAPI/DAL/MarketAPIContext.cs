using MarketAPI.Models;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarketAPI.DAL
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class MarketAPIContext : DbContext
    {
        public MarketAPIContext() : base("DefaultConnection") { }

        // Constructor to use on a DbConnection that is already opened
        public MarketAPIContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public DbSet<Supermercado> Supermercado { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}