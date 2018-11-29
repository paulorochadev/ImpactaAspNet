using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using Oficina.Dominio;
using System.Xml.Linq;
using System.IO;
using static System.Configuration.ConfigurationManager;
using System.Xml.Serialization;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class VeiculoRepositorio
    {
        private readonly string caminhoArquivo;
        private XDocument arquivoXml;

        public VeiculoRepositorio()
        {
            caminhoArquivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                AppSettings["caminhoArquivoVeiculo"]);
        }

        public void Inserir(Veiculo veiculo)
        {
            arquivoXml = XDocument.Load(caminhoArquivo);

            var registro = new StringWriter();

            new XmlSerializer(typeof(Veiculo)).Serialize(registro, veiculo);

            arquivoXml.Root.Add(XElement.Parse(registro.ToString()));

            arquivoXml.Save(caminhoArquivo);
        }
    }
}
