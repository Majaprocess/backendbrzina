namespace backendbrzina.Migrations
{
    using backendbrzina.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<backendbrzina.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(backendbrzina.Models.ApplicationDbContext context)
        {
            context.Places.AddOrUpdate(x => x.Id, 
                new Place() { Id = 1, Name="Novi Sad", PostalCode=21000 },
                new Place() { Id = 2, Name = "Beograd", PostalCode = 11000 },
                new Place() { Id = 3, Name = "Subotica", PostalCode = 24000 }
            );
            context.SaveChanges();
            context.Festivals.AddOrUpdate(x => x.Id,
                new Festival() { Id = 1, Name = "Exit", YearStart = 2000, Price=1000M, PlaceID = 1 },
                new Festival() { Id = 2, Name = "Beerfest", YearStart = 2010, Price = 1200M, PlaceID = 2 },
                new Festival() { Id = 3, Name = "Hranafests", YearStart = 2005, Price = 1300M, PlaceID = 3 },
             new Festival() { Id = 4, Name = "Vinefests", YearStart = 2006, Price = 800M, PlaceID = 1 }
            ) ;
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
