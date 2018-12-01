using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    public class VeiculoPasseio : Veiculo
    {
        public Carroceria Carroceria { get; set; }

        public override List<string> Validar()
        {
            var erros = ValidarBase();

            if (!Enum.IsDefined(typeof(Carroceria), Carroceria))
            {
                erros.Add($"A Carroceria informada ({Carroceria}) não é Válida");
            }

            return erros;
        }
    }
}
