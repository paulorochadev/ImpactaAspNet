using System.Data.Entity.ModelConfiguration;
//---
using Loja.Dominio;


namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(200);
        }
    }
}