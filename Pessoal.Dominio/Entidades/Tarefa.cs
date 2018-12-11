using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pessoal.Dominio.Entidades
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Prioridade Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Observacoes { get; set; }
    }
}
