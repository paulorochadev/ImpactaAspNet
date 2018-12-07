using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagensOnline.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using ViagensOnline.Dominio;


namespace ViagensOnline.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class ViagensOnlineDbContextTests
    {
        private readonly ViagensOnlineDbContext db = new ViagensOnlineDbContext();

        [TestMethod()]
        public void InserirTest()
        {
            var destino = new Destino();

            destino.Pais = "Brasil";
            destino.Cidade = "São Paulo";
            destino.Nome = "Conheça São Paulo";
            destino.NomeImagem = "Paulista.png";

            db.Destinos.Add(destino);

            db.SaveChanges();
        }

        [TestMethod]
        public void AtualizarTest()
        {
            var destino = db.Destinos.Find(1);

            destino.Pais = "Argentina";
            destino.Cidade = "Buenos Aires";
            destino.Nome = "Conheça Buenos Aires";
            destino.NomeImagem = "Central.png";

            db.SaveChanges();

            destino = db.Destinos.Find(1);

            Assert.AreEqual(destino.Pais, "Argentina");
            Assert.AreEqual(destino.Cidade, "Buenos Aires");
            Assert.AreEqual(destino.Nome, "Conheça Buenos Aires");
            Assert.AreEqual(destino.NomeImagem, "Central.png");
        }

        [TestMethod]
        public void ExcluirTest()
        {
            var destino = db.Destinos.Find(1);

            db.Destinos.Remove(destino);

            db.SaveChanges();
        }
    }
}