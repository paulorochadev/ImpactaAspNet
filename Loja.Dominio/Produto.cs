using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int Estoque { get; set; }

        //1 para Muitos
        public Categoria Categoria { get; set; }

        //Muitos para Muitos
        public List<Pedido> Pedidos { get; set; }

        //1 para 1
        public ProdutoImagem Imagem { get; set; }

    }
}
