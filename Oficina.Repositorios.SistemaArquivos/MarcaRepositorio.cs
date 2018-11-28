using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using System.Configuration;
using Oficina.Dominio;
using System.IO;


namespace Oficina.Repositorios.SistemaArquivos
{
    public class MarcaRepositorio
    {
        private string camihoArquivo = ConfigurationManager.AppSettings["caminhoArquivoMarca"];

        public List<Marca> Selecionar()
        {
            var marcas = new List<Marca>();

            foreach (var linha in File.ReadAllLines(camihoArquivo))
            {
                var propriedades = linha.Split('|');

                var marca = new Marca();

                marca.Id = Convert.ToInt32(propriedades[0]);
                marca.Nome = propriedades[1];

                marcas.Add(marca);
            }

            return marcas;
        }

        public Marca Selecionar(int id)
        {
            Marca marca = null;

            foreach (var linha in File.ReadAllLines(camihoArquivo))
            {
                var propriedadesId = linha.Split('|');

                if (Convert.ToInt32(propriedadesId[0]) == id)
                {
                    marca = new Marca();

                    marca.Id = Convert.ToInt32(propriedadesId[0]);
                    marca.Nome = propriedadesId[1];

                    break;
                }
            }

            return marca;
        }
    }
}
