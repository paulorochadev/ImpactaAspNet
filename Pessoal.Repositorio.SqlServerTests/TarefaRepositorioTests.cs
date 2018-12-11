using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pessoal.Repositorio.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using Pessoal.Dominio.Entidades;


namespace Pessoal.Repositorio.SqlServer.Tests
{
    [TestClass()]
    public class TarefaRepositorioTests
    {
        private readonly TarefaRepositorio repositorio = new TarefaRepositorio();

        [TestMethod()]
        public void InserirTest()
        {
            var tarefa = new Tarefa();

            tarefa.Nome = "Passar Roupa";
            tarefa.Prioridade = Prioridade.Alta;
            tarefa.Concluida = false;
            tarefa.Observacoes = "Rápido";

            tarefa.Id = repositorio.Inserir(tarefa);

            Assert.AreNotEqual(tarefa.Id, 0);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var tarefa = new Tarefa();

            tarefa.Id = 1;
            tarefa.Nome = "Passar Roupa no Sábado";
            tarefa.Prioridade = Prioridade.Baixa;
            tarefa.Concluida = true;
            tarefa.Observacoes = "Bem Rápido";

            repositorio.Atualizar(tarefa);
        }
    }
}