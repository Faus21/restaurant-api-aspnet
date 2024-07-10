using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Models;
using System.Numerics;

namespace RestaurantApp.Entities.Config
{
    public class CityEfConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(e => e.CityId).HasName("City_pk");

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();
           

            builder.ToTable("City");

            City[] cities =
            {
                new City
                {
                    CityId = 1,
                    Name = "Paris"
                },

                new City
                {
                    CityId = 2,
                    Name = "Warsaw"
                }
            };

            builder.HasData(cities);
        }
    }
}
