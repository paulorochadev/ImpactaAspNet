using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using Pessoal.Dominio.Entidades;


namespace Pessoal.Dominio.Interfaces
{
    public interface ITarefaRepositorio
    {
        int Inserir(Tarefa tarefa);
        Tarefa Selecionar(int id);
        List<Tarefa> Selecionar();
        void Atualizar(Tarefa tarefa);
        void Excluir(int id);
    }
}
