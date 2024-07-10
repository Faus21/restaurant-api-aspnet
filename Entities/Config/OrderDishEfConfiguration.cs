using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantApp.Models;

namespace RestaurantApp.Entities.Config
{
    public class OrderDishEfConfiguration : IEntityTypeConfiguration<OrderDish>
    {
        public void Configure(EntityTypeBuilder<OrderDish> builder)
        {
            builder.HasKey(e => new { e.OrderId, e.DishId}).HasName("OrderDish_pk");

            builder.Property(e => e.Quantity).IsRequired();

            builder.ToTable("OrderDish");

            OrderDish[] orderDishes =
            {
                new OrderDish
                {
                    OrderId = 1,
                    DishId = 1,
                    Quantity = 4
                },
                new OrderDish
                {
                    OrderId = 1,
                    DishId = 2,
                    Quantity = 2
                }
            };

            builder.HasData(orderDishes);
        }
    }
}
