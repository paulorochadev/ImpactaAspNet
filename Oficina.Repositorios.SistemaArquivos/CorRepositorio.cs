using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//---
using Oficina.Dominio;
using System.IO;
using static System.Configuration.ConfigurationManager;

namespace Oficina.Repositorios.SistemaArquivos
{
    public class CorRepositorio : RepositorioBase
    {
        //const string caminhoArquivo = @"Dados\Cor.txt";

        //ToDo: Implementar Método de Extensão
        private string caminhoArquivo;

        public CorRepositorio()
        {
            caminhoArquivo = ObterCaminhoCompleto("caminhoArquivoCor");
        }

        //ToDo: Orientação a Objetivo - Polimorfismo por SobreCarga
        public List<Cor> Selecionar()
        {
            var cores = new List<Cor>();

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var cor = new Cor();

                cor.Id = Convert.ToInt32 (linha.Substring(0, 5));
                cor.Nome = linha.Substring(5);

                cores.Add(cor);
            }

            return cores;
        }

        public Cor Selecionar(int id)
        {
            //int? x = null; // Para Deixar um Valor PRIMITIVO como NULO

            Cor cor = null;
            
            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var linhaId = linha.Substring(0, 5);

                if (Convert.ToInt32(linhaId) == id)
                {
                    cor = new Cor();

                    cor.Id = Convert.ToInt32(linha.Substring(0, 5));
                    cor.Nome = linha.Substring(5);

                    break;
                }
            }

            return cor;
        }
    }
}
