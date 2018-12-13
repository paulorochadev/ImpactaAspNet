using System;
using System.Collections.Generic;

namespace Loja.Dominio
{
    public class Pedido
    {
        public int Id { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public Cliente Cliente { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}