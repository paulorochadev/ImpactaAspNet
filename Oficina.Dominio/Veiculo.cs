//---
using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    //ToDo: Orientação a Objetos - Classe (Entidade) ou Abstração.

    public abstract class Veiculo //: Object
    {
        //public Veiculo()
        //{
        //    Id = Guid.NewGuid();
        //}

        public Guid Id { get; set; } = Guid.NewGuid();

        //private string placa;

        //public string Placa
        //{
        //    get
        //    {
        //        return placa.ToUpper();
        //    }
        //    set
        //    {
        //        placa = value.ToUpper();
        //    }
        //}

        private string placa;

        //ToDo: Orientação a Objetivo - Encapsulamento
        public string Placa
        {
            get { return placa?.ToUpper(); }
            set { placa = value?.ToUpper(); }
        }

        public int Ano { get; set; }
        public string Observacao { get; set; }
        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }
        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }

        //ToDo: Orientação a Objetivo - Encapsulamento
        public DateTime Agora
        {
            get { return DateTime.Now; }
        }
        
        public abstract List<string> Validar();

        protected List<string>ValidarBase()
        {
            var erros = new List<string>();

            if (Ano < 1980 || Ano > DateTime.Now.Year + 1)
            {
                erros.Add($"O Ano informado ({Ano}) não é Válido");
            }

            return erros;
        }

        public override string ToString()
        {
            //return base.ToString();

            return string.Format(" {0} {1} {2}", Modelo.Marca.Nome, Modelo.Nome, Placa);
        }
    }
}