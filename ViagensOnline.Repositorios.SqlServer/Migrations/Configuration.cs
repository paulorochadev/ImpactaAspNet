namespace ViagensOnline.Repositorios.SqlServer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ViagensOnline.Repositorios.SqlServer.ViagensOnlineDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ViagensOnline.Repositorios.SqlServer.ViagensOnlineDbContext";
        }

        protected override void Seed(ViagensOnline.Repositorios.SqlServer.ViagensOnlineDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
