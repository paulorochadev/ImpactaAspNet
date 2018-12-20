using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using System.Data.Entity;
using ViagensOnline.Dominio;
using System.Data.Entity.ModelConfiguration.Conventions;
using ViagensOnline.Repositorios.SqlServer.Migrations;


namespace ViagensOnline.Repositorios.SqlServer
{
    // DbContext é um Unit of Work

    public class ViagensOnlineDbContext : DbContext
    {
        public ViagensOnlineDbContext() : base("viagensOnlineSqlServer")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ViagensOnlineDbContext, Configuration>());
        }

        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}