namespace Garage2.Migrations
{
    using Garage2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage2.Models.Garage2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Garage2.Models.Garage2Context";
        }

        protected override void Seed(Garage2.Models.Garage2Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Vehicles.AddOrUpdate(
              v => v.RegNr,
              new Vehicle { RegNr = "AAA111", Type = VType.Car, Brand = "Audi", ProdName = "90", Color = "Red", Wheels = 4, CheckInTime=DateTime.Now },
              new Vehicle { RegNr = "BBB222", Type = VType.Car, Brand = "Volvo", ProdName = "XC90", Color = "Black", Wheels = 4, CheckInTime = DateTime.Now },
              new Vehicle { RegNr = "CCC333", Type = VType.Car, Brand = "Fiat", ProdName = "Uno", Color = "Yellow", Wheels = 4, CheckInTime = DateTime.Now }
              
            );
            

           
        }

    

    }
}
