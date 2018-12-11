using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pessoal.Dominio.Entidades;
//---
using Pessoal.Dominio.Interfaces;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace Pessoal.Repositorio.SqlServer
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly string stringConexao = ConfigurationManager.ConnectionStrings["pessoalSqlServer"].ConnectionString;


        public void Atualizar(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaAtualizar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa).ToArray());
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public int Inserir(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaInserir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa).ToArray());

                    return (int)comando.ExecuteScalar();
                }
            }
        }

        private List<SqlParameter> Mapear(Tarefa tarefa)
        {
            var parametros = new List<SqlParameter>();

            if (tarefa.Id > 0)
            {
                parametros.Add(new SqlParameter("@id", tarefa.Id));
            }

            parametros.Add(new SqlParameter("@nome", tarefa.Concluida));
            parametros.Add(new SqlParameter("@prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@observacoes", tarefa.Observacoes));
            
            return parametros;
        }

        public Tarefa Selecionar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tarefa> Selecionar()
        {
            throw new NotImplementedException();
        }
    }
}
