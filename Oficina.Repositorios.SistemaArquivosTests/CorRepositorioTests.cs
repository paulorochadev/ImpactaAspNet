using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class CorRepositorioTests
    {
        CorRepositorio corRepositorio = new CorRepositorio();

        [TestMethod()]
        public void SelecionarTest()
        {
            var cores = corRepositorio.Selecionar();

            foreach (var cor in cores)
            {
                Console.WriteLine($"{ cor.Id}: { cor.Nome}");
            }
        }

        [TestMethod()]
        public void SelecionarPorId()
        {
            var cor = corRepositorio.Selecionar(2);
            Assert.IsTrue(cor.Nome == "Azul");

            cor = corRepositorio.Selecionar(0);
            Assert.IsNull(cor);
        }
    }
}