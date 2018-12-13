using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using System.Diagnostics;
using Loja.Dominio;


namespace Loja.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class LojaDbContextTests
    {
        private readonly LojaDbContext db = new LojaDbContext();

        public LojaDbContextTests()
        {
            db.Database.Log = LogarQuery;
        }

        private void LogarQuery(string query)
        {
            Debug.WriteLine(query);
        }

        [TestMethod()]
        public void InserirCategoriaTest()
        {
            var categoria = new Categoria();

            categoria.Nome = "Informática";

            db.Categorias.Add(categoria);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoTest()
        {
            var produto = new Produto();

            produto.Categoria = db.Categorias.Find(1);
            produto.Estoque = 3;
            produto.Nome = "Bic";
            produto.Preco = 22.03m;

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void InserirProdutoComNovaCategoriaTest()
        {
            var produto = new Produto();

            produto.Categoria = new Categoria { Nome = "Perfumaria" };
            produto.Estoque = 8;
            produto.Nome = "Barbeador";
            produto.Preco = 22.08m;

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void EditarProdutoTest()
        {
            //var produto = db.Produtos.Where(p => p.Nome.Contains("Bic"));
            var produto = db.Produtos
                .Where(p => p.Nome == "Bic")
                .FirstOrDefault();

            produto.Categoria = db.Categorias.Find(2);
            produto.Estoque = 23;
            produto.Nome = "Perfume";
            produto.Preco = 22.23m;

            db.Produtos.Add(produto);
            db.SaveChanges();
        }

        [TestMethod]
        public void ExcluirProdutoTest()
        {
            var produtos = db.Produtos
                .Where(p => p.Categoria.Nome == "Informática")
                .ToList();

            db.Produtos.RemoveRange(produtos);

            db.SaveChanges();

            Assert.IsFalse(db.Produtos
                .Any(p => p.Categoria.Nome == "Informática"));
        }
    }
}