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
            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaExcluir", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();
                }
            }
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

            parametros.Add(new SqlParameter("@nome", tarefa.Nome));
            parametros.Add(new SqlParameter("@prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@observacoes", tarefa.Observacoes));
            
            return parametros;
        }

        public Tarefa Selecionar(int id)
        {
            Tarefa tarefa = null;

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@id", id);

                    using (var registros = comando.ExecuteReader())
                    {
                        if (registros.Read())
                        {
                            tarefa = Mapear(registros);
                        }
                    }
                }
            }

            return tarefa;
        }

        public List<Tarefa> Selecionar()
        {
            var tarefas = new List<Tarefa>();

            using (var conexao = new SqlConnection(stringConexao))
            {
                conexao.Open();

                using (var comando = new SqlCommand("TarefaSelecionar", conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registros = comando.ExecuteReader())
                    {
                        while (registros.Read())
                        {
                            tarefas.Add(Mapear(registros));
                        }
                    }
                }
            }

            return tarefas;
        }

        private Tarefa Mapear(SqlDataReader registros)
        {
            var tarefa = new Tarefa();

            tarefa.Id = Convert.ToInt32(registros["Id"]);
            tarefa.Nome = registros["Nome"].ToString();
            tarefa.Prioridade = (Prioridade)Convert.ToInt32(registros["Prioridade"]);
            tarefa.Concluida = Convert.ToBoolean(registros["Concluida"]);
            tarefa.Observacoes = Convert.ToString(registros["Observacoes"]);

            return tarefa;
        }
    }
}
