using System.Data.Entity.ModelConfiguration;
//---
using Loja.Dominio;


namespace Loja.Repositorios.SqlServer.ModelConfiguration
{
    public class CategoriaConfiguration : EntityTypeConfiguration<Categoria>
    {
        public CategoriaConfiguration()
        {
            Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(200);
        }
    }
}