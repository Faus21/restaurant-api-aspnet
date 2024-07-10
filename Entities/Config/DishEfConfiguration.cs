using Microsoft.EntityFrameworkCore;
using RestaurantApp.Models;

namespace RestaurantApp.Entities.Config
{
    public class DishEfConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(e => e.DishId).HasName("Dish_pk");

            builder.Property(e => e.DishName).HasMaxLength(50).IsRequired();

            builder.ToTable("Dish");

            Dish[] dishes =
            {
                new Dish
                {
                    DishId = 1,
                    DishName = "Tomato Soup"
                },
                new Dish
                {
                    DishId = 2,
                    DishName = "Fries"
                }
            };

            builder.HasData(dishes);
        }
    }
}
