using Loja.Dominio;
using Loja.Mvc.Models;
using Loja.Repositorios.SqlServer;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
//---
using Loja.Mvc.Areas.Admin.Models;


namespace Loja.Mvc.Mapeamento
{
    public class ProdutoMapeamento
    {
        public List<ProdutoViewModel> Mapear(List<Produto> produtos)
        {
            var produtosViewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                produtosViewModel.Add(Mapear(produto));
            }

            return produtosViewModel;
        }

        public Produto Mapear(ProdutoViewModel viewModel, LojaDbContext dbContext)
        {
            var produto = new Produto();

            produto.Categoria = dbContext.Categorias.Find(viewModel.CategoriaId);
            produto.Estoque = viewModel.Estoque;
            produto.Nome = viewModel.Nome;
            produto.Preco = viewModel.Preco;
            produto.Ativo = viewModel.Ativo;

            return produto;
        }

        public ProdutoViewModel Mapear(Produto produto, List<Categoria> categorias = null)
        {
            var viewModel = new ProdutoViewModel();

            viewModel.CategoriaId = produto.Categoria?.Id;
            viewModel.CategoriaNome = produto.Categoria?.Nome;

            if (categorias != null)
            {
                foreach (var categoria in categorias)
                {
                    viewModel.Categorias.Add(new SelectListItem { Text = categoria.Nome, Value = categoria.Id.ToString() });
                }
            }

            viewModel.Estoque = produto.Estoque;
            viewModel.Id = produto.Id;
            viewModel.Nome = produto.Nome;
            viewModel.Preco = produto.Preco;
            viewModel.Ativo = produto.Ativo;

            return viewModel;
        }

        public void Mapear(ProdutoViewModel viewModel, Produto produto, LojaDbContext dbContext)
        {
            dbContext.Entry(produto).CurrentValues.SetValues(viewModel);

            produto.Categoria = dbContext.Categorias.Single(c => c.Id == viewModel.CategoriaId);
        }
    }
}