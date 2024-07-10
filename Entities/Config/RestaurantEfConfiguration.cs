using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Entities.Config
{
    public class RestaurantEfConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasKey(e => e.RestaurantId).HasName("Restaurant_pk");

            builder.HasOne(e => e.City)
                .WithMany(e => e.Restaurants)
                .HasForeignKey(e => e.CityId)
                .HasConstraintName("Restaurant_City")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(e => e.Places).IsRequired();


            builder.ToTable("Restaurant");

            Restaurant[] restaurants =
            {
                new Restaurant
                {
                    RestaurantId = 1,
                    CityId = 1,
                    Places = 50
                },

                new Restaurant
                {
                    RestaurantId = 2,
                    CityId = 2,
                    Places = 120
                }
            };

            builder.HasData(restaurants);
        }
    }
}
