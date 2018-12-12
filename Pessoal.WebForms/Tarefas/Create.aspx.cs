using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//---
using Pessoal.Dominio.Entidades;
using Pessoal.Repositorio.SqlServer;

namespace Pessoal.WebForms.Tarefas
{
    public partial class Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public List<Prioridade> ObterPrioridades()
        {
            return Enum.GetValues(typeof(Prioridade)).Cast<Prioridade>().ToList();
        }

        protected void gravarButton_Click(object sender, EventArgs e)
        {
            var tarefa = new Tarefa();

            tarefa.Nome = nomeTextBox.Text;
            tarefa.Concluida = concluidaCheckBox.Checked;
            tarefa.Observacoes = observacoesTextBox.Text;

            Enum.TryParse(prioridadeDropDownList.SelectedValue, out Prioridade prioridadeSelecionada);

            tarefa.Prioridade = prioridadeSelecionada;

            new TarefaRepositorio().Inserir(tarefa);

            Response.Redirect("Default");
        }
    }
}