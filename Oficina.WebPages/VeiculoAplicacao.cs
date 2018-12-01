using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oficina.Dominio;
//---
using Oficina.Repositorios.SistemaArquivos;

namespace Oficina.WebPages
{
    public class VeiculoAplicacao
    {
        private readonly VeiculoRepositorio veiculoRepositorio = new VeiculoRepositorio();
        private readonly MarcaRepositorio marcaRepositorio = new MarcaRepositorio();
        private readonly ModeloRepositorio modeloRepositorio = new ModeloRepositorio();
        private readonly CorRepositorio corRepositorio = new CorRepositorio();

        public VeiculoAplicacao()
        {
            PopularControles();
        }

        public List<Marca> Marcas { get; private set; }
        public string MarcaSelecionada { get; set; }
        public List<Cor> Cores { get; private set; }
        public List<Combustivel> Combustiveis { get; private set; }
        public List<Cambio> Cambios { get; private set; }
        public List<Modelo> Modelos { get; private set; } = new List<Modelo>();

        private void PopularControles()
        {
            Marcas = marcaRepositorio.Selecionar();
            MarcaSelecionada = HttpContext.Current.Request.QueryString["marcaId"];

            if (!string.IsNullOrEmpty(MarcaSelecionada))
            {
                Modelos = modeloRepositorio.SelecionarPorMarca(Convert.ToInt32(MarcaSelecionada));
            }

            Cores = corRepositorio.Selecionar();

            Combustiveis = Enum.GetValues(typeof(Combustivel)).Cast<Combustivel>().ToList();
            Cambios = Enum.GetValues(typeof(Cambio)).Cast<Cambio>().ToList();
        }

        public void Inserir()
        {
            var veiculo = new VeiculoPasseio();
            var formulario = HttpContext.Current.Request.Form;

            veiculo.Ano = Convert.ToInt32(formulario["ano"]);
            veiculo.Cambio = (Cambio)Convert.ToInt32(formulario["cambio"]);
            veiculo.Carroceria = Carroceria.Hatch;
            veiculo.Combustivel = (Combustivel)Convert.ToInt32(formulario["combustivel"]);
            veiculo.Cor = corRepositorio.Selecionar(Convert.ToInt32(formulario["cor"]));
            veiculo.Modelo = modeloRepositorio.Selecionar(Convert.ToInt32(formulario["modelo"]));
            veiculo.Observacao = formulario["observação"];
            veiculo.Placa = formulario["placa"];

            veiculoRepositorio.Inserir(veiculo);
        }
    }
}