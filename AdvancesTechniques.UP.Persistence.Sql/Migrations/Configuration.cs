namespace AdvancedTechniques.UP.Persistence.Sql.Migrations
{
    using AdvancedTechniques.UP.Business.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AdvancedTechniques.UP.Persistence.Sql.RestaurantDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AdvancedTechniques.UP.Persistence.Sql.RestaurantDbContext context)
        {
            Random random = new Random();

            string tableName = string.Empty;

            for (int i = 0; i < 10; i++)
            {
                int capacityRandom = random.Next(2, 6);

                tableName = string.Format("Table {0}", i);

                context.Tables.AddOrUpdate(new Table { Name = tableName, Capacity = capacityRandom });
            }
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
