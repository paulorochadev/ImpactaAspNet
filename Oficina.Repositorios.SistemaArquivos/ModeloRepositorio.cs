using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using System.Xml.Linq;
using Oficina.Dominio;
using System.IO;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class ModeloRepositorio
    {
        private XDocument arquivoXml =
            XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                AppSettings["caminhoArquivoModelo"]));

        /// <summary>
        /// Seleciona os modelos de veículo.
        /// </summary>
        /// <param name="marcaId"></param>
        /// <returns></returns>
        public List<Modelo> SelecionarPorMarca(int marcaId)
        {
            var modelos = new List<Modelo>();

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("marcaId").Value == marcaId.ToString())
                {
                    var modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;

                    modelo.Marca = new MarcaRepositorio().Selecionar(marcaId);

                    modelos.Add(modelo);
                }
            }

            return modelos;
        }

        public Modelo Selecionar(int id)
        {
            Modelo modelo = null;

            foreach (var elemento in arquivoXml.Descendants("modelo"))
            {
                if (elemento.Element("id").Value == id.ToString())
                {
                    modelo = new Modelo();

                    modelo.Id = Convert.ToInt32(elemento.Element("id").Value);
                    modelo.Nome = elemento.Element("nome").Value;

                    modelo.Marca = new MarcaRepositorio().Selecionar (Convert.ToInt32(elemento.Element("marcaId").Value));

                    break;
                }
            }

            return modelo;
        }
    }
}
