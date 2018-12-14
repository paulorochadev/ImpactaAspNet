using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using System.Data.Entity;
using Loja.Dominio;
using System.Data.Entity.ModelConfiguration.Conventions;
using Loja.Repositorios.SqlServer.ModelConfiguration;
using Loja.Repositorios.SqlServer.Migrations;


namespace Loja.Repositorios.SqlServer
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext() : base("lojaSqlServer")
        {
            //Database.SetInitializer(new LojaDbInitializer()); DROP a BASE e CRIAR um Banco NOVO

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LojaDbContext, Configuration>());

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //#region Produto
            //#endregion

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new CategoriaConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoImagemConfiguration());
        }

        public System.Data.Entity.DbSet<Loja.Dominio.ProdutoImagem> ProdutoImagem { get; set; }
    }
}
