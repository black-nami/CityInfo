using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options)
        {
            
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<PointOfInterest> PointOfInterest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City("New Your City")
                { Id = 1, Description = "The one with that big park" },
                new City("Antwerp")
                { Id = 2, Description = "The one with the cathedral" },
                new City("Paris")
                { Id = 3, Description = "The one with that big tower" });

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("Central Park")
                { Id = 1, CityId = 1, Description = "Central Park Description" },
                new PointOfInterest("Empire Estate Building")
                { Id = 2, CityId = 1, Description = "Empire Estate Building Description" },
                new PointOfInterest("Cathedral")
                { Id = 3, CityId = 2, Description = "Cathedral Description" },
                new PointOfInterest("Central Station")
                { Id = 4, CityId = 2, Description = "Central Station Description" },
                new PointOfInterest("Eiffel Tower")
                { Id = 5, CityId = 3, Description = "Eiffel Tower Description" },
                new PointOfInterest("The Lourve")
                { Id = 6, CityId = 3, Description = "The Lourve Description" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
