namespace Loja.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    //---
    using System.Collections.Generic;
    using Loja.Dominio;


    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Repositorios.SqlServer.LojaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Loja.Repositorios.SqlServer.LojaDbContext";
        }

        protected override void Seed(LojaDbContext context)
        {
            //context.Database.ExecuteSqlCommand(""); //Criar o banco a partir de "Qualquer" comando SQL

            if (!context.Produtos.Any())
            {
                context.Produtos.AddRange(ObterProdutos());
                context.SaveChanges();
            }
        }

        private IEnumerable<Produto> ObterProdutos()
        {
            var grampeador = new Produto();

            grampeador.Categoria = new Categoria { Nome = "Papelaria" };
            grampeador.Estoque = 29;
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 22.08m;

            var penDrive = new Produto();

            penDrive.Categoria = new Categoria { Nome = "Informática" };
            penDrive.Estoque = 35;
            penDrive.Nome = "Pen Drive";
            penDrive.Preco = 25.05m;

            return new List<Produto> { grampeador, penDrive };
        }
    }
}
