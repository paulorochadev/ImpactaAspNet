using System.Data.Entity.ModelConfiguration;
//---
using Loja.Dominio;


namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            HasRequired(p => p.Cliente);
        }
    }
}