namespace BackendStore.Migrations
{
    using BackendStore.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BackendStore.Models.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BackendStore.Models.AppDbContext context)
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

            context.Products.Add(new Product()
            {
                Name = "Skirt",
                Description = "The element of scout uniform, made of durable fabric",
                IsStore = false,
                IsStock = true,
                Count = 3,
                CountStore = 1,
                CountStock = 1,
                Color = "green",
                Size = "small",
                Ordered = 1,
                Comment = "In stock means 'in working'"
            });

        }
    }
}
