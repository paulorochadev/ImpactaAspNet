using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oficina.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using Oficina.Dominio;

namespace Oficina.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class VeiculoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var veiculo = new VeiculoPasseio();

            veiculo.Placa = "ABC1234";
            veiculo.Ano = 2014;
            veiculo.Observacao = "Observação";
            veiculo.Modelo = new ModeloRepositorio().Selecionar(1);
            veiculo.Cor = new CorRepositorio().Selecionar(1);
            veiculo.Combustivel = Combustivel.Flex;
            veiculo.Cambio = Cambio.Automatico;
            veiculo.Carroceria = Carroceria.Hatch;

            new VeiculoRepositorio().Inserir(veiculo);
        }
    }
}