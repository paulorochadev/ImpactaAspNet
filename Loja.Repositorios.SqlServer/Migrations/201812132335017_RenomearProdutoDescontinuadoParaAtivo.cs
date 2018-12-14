namespace Loja.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenomearProdutoDescontinuadoParaAtivo : DbMigration
    {
        public override void Up()
        {
            //Sql(""); // Criar um "Comando SQL" para Enviar as Informações para outro tabela e etc

            AddColumn("dbo.Produto", "Ativo", c => c.Boolean(nullable: false, defaultValue: true));
            DropColumn("dbo.Produto", "Descontinuado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Produto", "Descontinuado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Produto", "Ativo");
        }
    }
}
