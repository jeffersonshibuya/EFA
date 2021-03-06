using Efa.Infra.CrossCutting.Identity.Context;

namespace Efa.Infra.CrossCutting.Identity.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //SetSqlGenerator("MySql.Data.MySqlClient", new MySqlMigrationSqlGenerator());
            //SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
        }

        protected override void Seed(IdentityContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
